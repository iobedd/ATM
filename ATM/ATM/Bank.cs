using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Bank
    {
        public List<Card>? Cards;
        //public string BankName;
        //public Id;
        public Bank() { }
        public Bank(List<Card> cards)
        {
            this.Cards = cards;
        }
        public bool CodeCorrect(int ok)
        {//verif Pin exista 
            foreach (Card card in Cards)
            {
                if(card.AccessGrant(ok))
                    return true;
                    
            }
            return false;
        }
    }
}
