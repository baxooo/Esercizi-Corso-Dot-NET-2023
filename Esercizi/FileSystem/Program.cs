using FileSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(25, "Antonio"));
            customers.Add(new Customer(34, "Carlo"));
            customers.Add(new Customer(31, "Alessia"));
            customers.Add(new Customer(65, "Maria"));
            customers.Add(new Customer(53, "Franco"));
            customers.Add(new Customer(44, "Carmelo"));
            customers.Add(new Customer(38, "Barbara"));
            customers.Add(new Customer(61, "Sara"));
            customers.Add(new Customer(29, "Luca"));

            List<Account> accounts = new List<Account>();
            accounts.Add(new Account(1, 654.30m));
            accounts.Add(new Account(2, 1624.76m));
            accounts.Add(new Account(3, 2541.23m));
            accounts.Add(new Account(4, 6241.93m));
            accounts.Add(new Account(5, 355.34m));
            accounts.Add(new Account(6, 1854.55m));
            accounts.Add(new Account(7, 54354.54m));
            accounts.Add(new Account(8, 3614.76m));
            accounts.Add(new Account(9, 64.82m));

            string path = Directory.GetCurrentDirectory();

            CreateCsv(path, "customerFile.csv", customers);
            CreateCsv(path, "AccountFile.csv", accounts);

            CreateGenericCsv(path, "file.csv", accounts);
        }

        static void CreateCsv(string path, string fileName, List<Customer> customers)
        {
            StringBuilder sb = new StringBuilder();
            
            string completePath = Path.Combine(path, fileName);
            if(!File.Exists(completePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }
            foreach(var customer in customers)
            {
                sb.AppendLine(customer.Name+ "," + customer.Age);
            }

            File.AppendAllText(completePath, sb.ToString());
        }

        static void CreateCsv(string path, string fileName, List<Account> accounts)
        {
            StringBuilder sb = new StringBuilder();

            string completePath = Path.Combine(path, fileName);
            if (!File.Exists(completePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }
            foreach (var account in accounts)
            {
                sb.AppendLine(account.AccountId + "," + account.Saldo);
            }

            File.AppendAllText(completePath, sb.ToString());
        }
        //static void CreateGenericCsv<T>(string path,string fileName, List<T> dati)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    string completePath = Path.Combine(path, fileName);

        //    if (!File.Exists(completePath))
        //    {
        //        string header = string.Format("Name,Age");
        //        sb.AppendLine(header);
        //    }
            
        //    foreach (var dato in dati)
        //    {
        //        if(dato is Account account)
        //            sb.AppendLine($"{account.AccountId},{account.Saldo}");
        //        if (dato is Customer customer)
        //            sb.AppendLine($"{customer.Name},{customer.Age}");
        //    }

        //    File.AppendAllText(completePath, sb.ToString());
        //}
        static void CreateGenericCsv<T>(string path, string fileName, List<T> dati)
        {
            StringBuilder sb = new StringBuilder();
            string completePath = Path.Combine(path, fileName);

            Type type = typeof(T);
            var properties = type.GetProperties();

            if (!File.Exists(completePath))
            {
                string header;
                string format = string.Empty;

                var dato = dati[0];
                foreach (var property in properties)
                {
                    var value = property.GetValue(dato);
                    //Console.WriteLine($"{property.Name}, {value}");
                    format += $"{property.Name},";
                }
                
                header = string.Format(format.Trim(','));
                //Console.WriteLine(header);
                sb.AppendLine(header);
            }

            foreach (var dato in dati)
            {
                string[] valuesToAppend = new string[2];
                for (int i = 0; i <= properties.Length - 1; i++)
                {
                    var property = properties[i];
                    var value = property.GetValue(dato);
                    valuesToAppend[i] = value.ToString();
                    //Console.WriteLine($"{property.Name}, {value}");
                }
                sb.AppendLine(string.Join(',',valuesToAppend));
                //Console.WriteLine(string.Join(',', valuesToAppend));
            }

            File.AppendAllText(completePath, sb.ToString());
        }
    }
}
