using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    public class Logger
    {
        private static Logger _instance;

        private static readonly object lockObject = new object();


        public string FilePath { get; set; }
        private Logger()
        {
            
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Log(string filePath,LogTypeEnum type, string message)
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"[{DateTime.Now}] [{type}]: {message}");
            }
        }

        public void Log(LogTypeEnum type, string message)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }


            using (StreamWriter writer = File.AppendText(FilePath))
            {
                writer.WriteLine($"[{DateTime.Now}] [{type}]: {message}");
            }
        }
    }
}
