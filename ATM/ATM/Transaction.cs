using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }

        public Transaction(DateTime date, int amount, string name)
        {
            Date = date;
            Amount = amount;
            Name = name ;
        }
        public Transaction() { }

        public void ShowTransaction(Transaction transactions)
        {
                Console.WriteLine("Name: " + transactions.Name + " ; amount:" + transactions.Amount + " happend at " + transactions.Date);
        }
    }
}
