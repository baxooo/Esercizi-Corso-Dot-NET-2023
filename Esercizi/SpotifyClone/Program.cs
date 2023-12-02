using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SpotiLogLibrary;

namespace SpotifyClone
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.Instance;
            string loggerFilePath = @"D:/Log.txt";
            logger.FilePath = loggerFilePath;
            
            ClasseUI classe = new ClasseUI();
            classe.LogMenu();
        }
    }
}
