using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Card
    {
        public int Money;
        public string OwnerName;
        public int CardId;
        public int Pin;

        public Card(int money, string cardOwnerName, int cardId, int pin)
        {
            this.Money = money;
            this.OwnerName = cardOwnerName;
            this.CardId = cardId;
            this.Pin = pin;
        }

        public bool AccessGrant(int cod)
        {//pt acces la card
            if(cod == Pin)
            {
                return true;
            }
            return false;
        }
        
        public int WithdrawMoney(int amount)
        {
            bool steag = false;
            if (amount > Money)
            {
                Console.WriteLine("The amount is over your balance.");
                Console.WriteLine("Rewrite amount");
                Console.WriteLine("Amount?");
                steag = true;
                int a1 = int.Parse(Console.ReadLine());
                amount = WithdrawMoney(a1);
            }
            else
            {
                if(amount == Money )
                {
                     Console.WriteLine("This amount is your full balance, are you sure you want to withdraw all? n-no/y-anything else");
                     char i2 = Console.ReadLine()[0];
                        if (i2 == 'n')
                        {
                            Console.WriteLine("Amount?");
                            int a = int.Parse(Console.ReadLine());
                            steag = true;
                            amount = WithdrawMoney(a);  
                        }
                }
            }
            if(steag == true)
            {
                Money = Money - amount;
                Console.WriteLine("You withdrew " + amount + "RON from your account!");
            }
            return amount;
        }

        public void MoneyTransfer(Card card ,int amount)
        {
            card.Money = card.Money - amount;
        }
        public void PayBill(int amount)
        {
            if(amount > Money)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                Money = Money - amount;
                Console.WriteLine("You have payed this bill succeesfully");
            }
        }

        internal int DepositMoney(Card card)
        {
            Console.WriteLine("Amount to deposit?");
            int a2 = int.Parse(Console.ReadLine());
            card.Money = card.Money + a2;
            return a2;
        }
    }

}
