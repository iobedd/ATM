using ATM;


var bank = new Bank
{
    Cards = new List<Card>()
};

Card cardu = new Card(1000, "Mojo Dojo", 1, 2020);
bank.Cards.Add(cardu);
Card cardu2 = new Card(10001, "Scooby Dog", 2, 2456);
bank.Cards.Add(cardu2);
Card cardu3 = new Card(30, "Tester", 3, 1234);
bank.Cards.Add(cardu3);

History history = new History();
List<Bill>? bills = new List<Bill> //the premade bills 
    {
        new Bill
        {
            Id = 1,
            Name = "Electricity",
            Value = 500,
            Status = false,
        },
        new Bill
        {
            Id = 2,
            Name = "Internet",
            Value = 100,
            Status = false,
        },
        new Bill
        {
            Id = 3,
            Name = "Water",
            Value = 200,
            Status = false,
        }
    };

List<Transaction> transactions = new List<Transaction>(); //will keep track of atm history
Transaction transaction = new Transaction();
string TransName;
int TransCounter = 0;
DateTime Acum = DateTime.Now;

MENIU:

Console.WriteLine("\n       MENU:");
Console.WriteLine("---------------------");
Console.WriteLine("     1. INSERT");
Console.WriteLine("     2. WITHDRAW");
Console.WriteLine("     3. BLOCK");
Console.WriteLine("     4. CREATE NEW CARD");
Console.WriteLine("     5. EXIT ATM");
Console.WriteLine("---------------------");

char i1 = 'a';
Console.WriteLine("Option? \n");
while (i1 != '1' && i1 != '2' && i1 != '3' && i1!= '4' && i1!= '5')
{
    i1 = Console.ReadLine()[0];
}
if (i1 == '1')
{   //insert
INSERT:
    Console.WriteLine("\nPIN?");
    int id2 = int.Parse(Console.ReadLine());
    //trb sa fac sa fie mai multe carduri disponibile pt logare
    //trb sa schimb sa nu fie bank.Cards[0] ci din id-ul cardului gasit la logare
    if (bank.CodeCorrect(id2))
    {
    InsertMenu:
        Console.WriteLine("\n     INSERT MENU:    ");
        Console.WriteLine("---------------------");
        Console.WriteLine("     Withdraw money?  -w");
        Console.WriteLine("     Deposit  -d");
        Console.WriteLine("     Pay bills  -p");
        Console.WriteLine("     Show balance  -b");
        Console.WriteLine("     Leave insert-menu -n");
        Console.WriteLine("---------------------");

        char i3 = Console.ReadLine()[0];
        if (i3 == 'w')
        {
            Console.WriteLine("Amount?");
            int a1 = int.Parse(Console.ReadLine());
            int amount = bank.Cards[0].WithdrawMoney(a1);  //trb sch
            history.AddToHistory(transactions, amount, "withdraw");
        }
        else if (i3 == 'd')
        {
            int amount2 = bank.Cards[0].DepositMoney(bank.Cards[0]);
            history.AddToHistory(transactions, amount2, "deposit");
        }
        else if (i3 == 'p')
        {
            foreach (Bill bill in bills)
            {
                if (bill.Status == false)
                {
                    Console.WriteLine("The bill: " + bill.Name + " with value " + bill.Value + "RON, payment status: " + bill.Status);
                }
            }
            Console.WriteLine("What bill do you want to select? write the name");
            string billname = Console.ReadLine();
            foreach (Bill bill in bills)
            {
                if (billname == bill.Name && bill.Status == true)
                {
                    Console.WriteLine("This bill was already paid");
                }
                else if (billname == bill.Name && bill.Status == false)
                {
                    bank.Cards[0].Money = bank.Cards[0].Money - bill.Value;
                    bill.Status = true;
                    history.AddToHistory(transactions, bill.Value, billname);
                }
            }
        }
        else if (i3 == 'b')
        {
            Console.WriteLine("History of transactions: ");
            history.ShowTrans(transactions);
            Console.WriteLine("\nCurrent balance of account:" + bank.Cards[0].Money + " RON left");
        }
        else if (i3 == 'n')
        {
            goto MENIU;
        }
        else goto InsertMenu;
        goto InsertMenu; //did an action? go to menu again
    }
    else goto INSERT;

    goto MENIU; //whenever an action is done user will be sent back to menu
}
else if (i1 == '2')
{  //wirhdraw

    goto MENIU;
}
else if (i1 == '3')
{  //block => delete?
    Console.WriteLine("The card with the nameholder: <" + bank.Cards[0].OwnerName + "> has been successfully been blocked/deleted.");
    bank.Cards.Remove(bank.Cards[0]);
    goto MENIU;
}
else if (i1 == '4')
{
    //card creation
    Console.WriteLine("Name of the card?");
    string tempName = Console.ReadLine();
    Console.WriteLine("Initial balance of the card?(money on card?)");
    int tempMoney = int.Parse(Console.ReadLine());
    Console.WriteLine("PIN of the card? -4 digits");
    int tempCode = int.Parse(Console.ReadLine());
    int tempId = bank.Cards.Count +1;

    Console.WriteLine("Card info will be: Name- "+ tempName + ", Balance- "+ tempMoney + ", PIN: "+ tempCode);
    var tempCard = new Card(tempMoney, tempName, tempId, tempCode);
    bank.Cards.Add(tempCard);
}
else if( i1 == '5')
{
    Console.WriteLine("Byebye");
}
else goto MENIU;

