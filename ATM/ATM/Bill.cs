using System;

namespace ATM
{
	public class Bill
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }

		public bool Status { get; set; }	//for paid or nah
		public Bill(int id, string name, int money, bool status)
		{
			this.Id = id;
			this.Name = name;
			this.Value = money;
			this.Status = status;
		}

		public Bill()
		{
		}

		public void ShowAvaliableBills(Bill bill)
		{
			if(bill.Status == true)
			{
				Console.WriteLine("The bill "+ bill.Name + " with the value: " + bill.Value + ".");
			}
		}
	}
}
