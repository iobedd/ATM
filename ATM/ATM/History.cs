using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class History
    {
        public List<Transaction>? transactions;
        public History() { }
        public History(List<Transaction>? transactions) {  this.transactions = transactions; }

        public void AddToHistory( List<Transaction> transactions, int Amount, string Name )
        {
            DateTime date = DateTime.Now;
            Transaction transaction = new Transaction { 
                Amount = Amount,
                Date = date,
                Name = Name
            };

            transactions.Add( transaction );
        }

        public void ShowTrans(List<Transaction>? transactions)
        {
            foreach( Transaction transaction in transactions )
            {
                transaction.ShowTransaction(transaction);
            }
        }
    }
}
