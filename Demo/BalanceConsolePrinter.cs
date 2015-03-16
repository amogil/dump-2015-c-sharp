using System;

namespace Dump2015.Demo
{
	public interface IBalanceConsolePrinter
	{
		void Print(IOwner owner, IBalanceCalculator balanceCalculator);
	}

	public class BalanceConsolePrinter : IBalanceConsolePrinter
	{
		public void Print(IOwner owner, IBalanceCalculator balanceCalculator)
		{
			Console.WriteLine("----------- RECEIPT -----------");
			Console.WriteLine("Customer: {0} ({1})", owner.Title, owner.Words);
			Console.WriteLine("Balance: {0} {1}", balanceCalculator.GetBalance(), balanceCalculator.Currency);
			Console.WriteLine("-------------------------------");
			Console.WriteLine();
		}
	}
}