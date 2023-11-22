using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    internal class Account
    {
        public int AccountId { get; set; }
        public decimal Saldo { get; set; }
        public Account(int accountId,decimal saldo)
        {
            AccountId = accountId ;
            Saldo = saldo;
        }
    }
}
