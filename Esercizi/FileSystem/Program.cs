using FileSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

            CreateCsv(path, "file.csv", customers);
        }

        static void CreateCsv(string path, string fileName,List<Customer> customers)
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
    }
}
