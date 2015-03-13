using System;

namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IBalanceCalculatorFactory _balanceCalculatorFactory;
		private readonly IOwnerFactory _ownerFactory;
		private readonly ITransactionCreatorFactory _transactionCreatorFactory;

		public Demo(IOwnerFactory ownerFactory, IBalanceCalculatorFactory balanceCalculatorFactory,
			ITransactionCreatorFactory transactionCreatorFactory)
		{
			_ownerFactory = ownerFactory;
			_balanceCalculatorFactory = balanceCalculatorFactory;
			_transactionCreatorFactory = transactionCreatorFactory;
		}

		public void Show()
		{
			var starks = _ownerFactory.Create("House Stark", "Winterfell", "Winter is Coming", Currency.Stags);
			var lannisters = _ownerFactory.Create("House Lannister", "Casterly Rock", "Hear Me Roar!", Currency.Dragons);

			var starksBalanceCalculator = _balanceCalculatorFactory.Create(starks.Account);
			var lannistersBalanceCalculator = _balanceCalculatorFactory.Create(lannisters.Account);

			PrintBalance(starks, starksBalanceCalculator);
			PrintBalance(lannisters, lannistersBalanceCalculator);

			var transactionCreator = _transactionCreatorFactory.Create(starks.Account, lannisters.Account);
			transactionCreator.Create(Currency.Dragons, 100, "Pwned by Lannisters");

			Console.WriteLine("{0} has taken {1} {2} from {3}\n", lannisters.Title, 100, Currency.Dragons, starks.Title);

			PrintBalance(starks, starksBalanceCalculator);
			PrintBalance(lannisters, lannistersBalanceCalculator);
		}

		private void PrintBalance(IOwner owner, IBalanceCalculator balanceCalculator)
		{
			Console.WriteLine("----------- RECEIPT -----------");
			Console.WriteLine("Customer: {0} ({1})", owner.Title, owner.Words);
			Console.WriteLine("Balance: {0} {1}", balanceCalculator.GetBalance(), balanceCalculator.Currency);
			Console.WriteLine("-------------------------------");
			Console.WriteLine();
		}
	}
}