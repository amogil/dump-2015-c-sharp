using System;

namespace Dump2015.Demo
{
	public interface IReceiptConsolePrinter
	{
		void Print(IOwner owner);
	}

	public class ReceiptConsolePrinter : IReceiptConsolePrinter
	{
		private readonly IKingsStateCalculator _kingsStateCalculator;

		public ReceiptConsolePrinter(IKingsStateCalculator kingsStateCalculator)
		{
			_kingsStateCalculator = kingsStateCalculator;
		}

		public void Print(IOwner owner)
		{
			var balance = owner.Account.GetBalance();
			Console.WriteLine("----------- RECEIPT -----------");
			Console.WriteLine("Customer: {0} ({1})", owner.Title, owner.Words);
			Console.WriteLine("Balance: {0} {1}", balance.Amount, balance.Currency);
			Console.WriteLine("King's envy: {0} ", _kingsStateCalculator.GetEnvy(owner));
			Console.WriteLine("-------------------------------");
			Console.WriteLine();
		}
	}
}