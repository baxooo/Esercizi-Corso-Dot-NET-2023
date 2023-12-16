using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ClientDataLayer
{
    internal abstract class DbContext
    {
        string _config;
        protected static ILogger _logger;
        protected DbContext(IConfiguration config,ILogger logger)
        {
            _logger = logger;
            _config = config.GetConnectionString("DefaultConnection");
        }

        public DbContext()
        {

        }

        protected virtual List<T> ReadDataFromCsv<T>(string path)
            where T : class, new()
        {
            if (!File.Exists(path))
            {
                _logger.LogWarning("csv file does not exist");
                return null;
            }

            return CreateObject<T>(File.ReadAllLines(path).ToList());
        }
        private static List<T> CreateObject<T>(List<string> file)
            where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = file.ElementAt(0).Split(',');
            file.RemoveAt(0);

            bool isDataset = true;
            T entry = new T();
            PropertyInfo[] prop = entry.GetType().GetProperties();

            if (isDataset)
            {
                for (int i = 0; i < prop.Length; i++)
                {
                    if (prop.ElementAt(i).Name == headers[i])
                        continue;
                    else isDataset = false;
                }
            }
            if (isDataset)
            {
                foreach (var line in file)
                {
                    entry = new T();

                    int j = 0;
                    string[] columns = line.Split(',');

                    foreach (var col in columns)
                    {
                        if (col == null || col == string.Empty)
                        {
                            j++;
                            continue;
                        }
                        try
                        {
                            var CurrentProp = entry.GetType().GetProperty(headers[j]).PropertyType;
                            if (CurrentProp.IsEnum)
                            {
                                object enumValue = Enum.Parse(CurrentProp, col);
                                entry.GetType().GetProperty(headers[j]).SetValue(entry, enumValue);
                            }
                            else
                                entry.GetType()
                                    .GetProperty(headers[j])
                                    .SetValue(entry, Convert.ChangeType(col, entry.GetType().GetProperty(headers[j])
                                    .PropertyType));
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message + "\n" + ex.StackTrace);
                        }
                        j++;
                    }

                    list.Add(entry);
                }
            }
            else _logger.LogError("Oggetto e File Csv hanno Dataset diversi!");

            return list;
        }

        public void WriteData<T>(IEnumerable<T> data) where T : class,new()
        {
            T entry = new T();
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var obj = data.Select(s => s.GetType().GetProperties());

            if (File.Exists(_config))
            {
                File.Delete(_config);
                File.Create(_config);
            }
            foreach (var cols in obj)
                foreach (var col in cols)
                {

                    sb.Append(col.Name);
                    sb.Append(',');
                }
            

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var cols in obj)
                    foreach (var col in cols)
                    {
                        sb.Append(col.GetValue(row));
                        sb.Append(',');

                    }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }

            list.RemoveAt(0);
            File.AppendAllLines(_config + entry.GetType().Name +".csv", list);
        }
    }
}
