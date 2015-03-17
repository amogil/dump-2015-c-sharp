namespace Dump2015.Demo
{
	public class Money
	{
		public Money(decimal amount, Currency currency)
		{
			Amount = amount;
			Currency = currency;
		}

		public decimal Amount { get; private set; }
		public Currency Currency { get; private set; }
	}
}