using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SpotiLogLibrary;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    public class CsvReader<T> where T : class, new()
    {
        public static List<T> CreateObject(List<string> csv, Logger log)
        {
            List<T> list = new List<T>();
            string[] headers = csv.ElementAt(0).Split(',');
            csv.RemoveAt(0); 

            bool isDatset = true;
            T entry = new T(); 
            PropertyInfo[] prop = entry.GetType().GetProperties();

            if (isDatset)
            {
                for (int i = 0; i < prop.Length; i++)
                {
                    if (prop.ElementAt(i).Name == headers[i])
                        continue;
                    else isDatset = false;
                }
            }
            if (isDatset)
            {
                csv.RemoveAt(0);
                foreach (var line in csv)
                {
                    entry = new T();

                    int j = 0;
                    string[] columns = line.Split(',');

                    foreach (var col in columns) 
                    {
                        if(col == null || col == string.Empty) continue;
                        try
                        {
                            entry.GetType()
                                .GetProperty(headers[j])
                                .SetValue(entry, Convert.ChangeType(col, entry.GetType().GetProperty(headers[j])
                                .PropertyType)  
                              );
                        }
                        catch
                        {
                            throw;
                        }
                        j++;
                    }

                    list.Add(entry);
                }
            }
            else log.Log(LogTypeEnum.ERROR, "Oggetto e File Csv hanno Dataset diversi!");

            return list;
        }
    }
}
