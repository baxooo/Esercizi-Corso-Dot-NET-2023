﻿using SpotiBackEnd.Models;
using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.DbContext
{
    public abstract class DbContext
    {
        string _config;
        protected DbContext(string config)
        {
            _config = config;
        }

        public DbContext()
        {
                
        }

        protected virtual List<T> ReadDataFromCsv<T>(string path, Logger logger) 
            where T  : class, new()
        {
            if (!File.Exists(path))
            {
                logger.Log(LogTypeEnum.WARNING, "csv file does not exist");
                return null;
            }

            return CreateObject<T>(File.ReadAllLines(path).ToList(),logger);
        }
        private static List<T> CreateObject<T>(List<string> file, Logger log) 
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
                            if(CurrentProp.IsEnum)
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
                        catch(Exception ex)
                        {
                            log.Log(LogTypeEnum.ERROR, ex.Message + "\n" + ex.StackTrace);
                        }
                        j++;
                    }

                    list.Add(entry);
                }
            }
            else log.Log(LogTypeEnum.ERROR, "Oggetto e File Csv hanno Dataset diversi!");

            return list;
        }

        public void WriteData<T>(IEnumerable<T> data)
        {

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = data.GetEnumerator().GetType().GetProperties();

            if (File.Exists(_config))
            {
                File.Delete(_config);
            }
            foreach (var col in cols)
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var col in cols)
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(_config, list);
        }
    }
}
