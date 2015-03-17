using System;

namespace Dump2015.Demo
{
	public interface IBalanceConsolePrinter
	{
		void Print(IOwner owner);
	}

	public class BalanceConsolePrinter : IBalanceConsolePrinter
	{
		private readonly IBalanceCalculator _balanceCalculator;

		public BalanceConsolePrinter(IBalanceCalculator balanceCalculator)
		{
			_balanceCalculator = balanceCalculator;
		}

		public void Print(IOwner owner)
		{
			Console.WriteLine("----------- RECEIPT -----------");
			Console.WriteLine("Customer: {0} ({1})", owner.Title, owner.Words);
			Console.WriteLine("Balance: {0} {1}", _balanceCalculator.GetBalance(owner.Account), owner.Account.Currency);
			Console.WriteLine("-------------------------------");
			Console.WriteLine();
		}
	}
}