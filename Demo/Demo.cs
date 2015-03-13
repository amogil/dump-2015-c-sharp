using System;

namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IBalanceCalculatorsFactory _balanceCalculatorsFactory;
		private readonly IOwnersFactory _ownersFactory;
		private readonly ITransactionCreatorsFactory _transactionCreatorsFactory;

		public Demo(IOwnersFactory ownersFactory, IBalanceCalculatorsFactory balanceCalculatorsFactory,
			ITransactionCreatorsFactory transactionCreatorsFactory)
		{
			_ownersFactory = ownersFactory;
			_balanceCalculatorsFactory = balanceCalculatorsFactory;
			_transactionCreatorsFactory = transactionCreatorsFactory;
		}

		public void Show()
		{
			var starks = _ownersFactory.Create("House Stark", "Winterfell", "Winter is Coming", Currency.Stags);
			var lannisters = _ownersFactory.Create("House Lannister", "Casterly Rock", "Hear Me Roar!", Currency.Dragons);

			var starksBalanceCalculator = _balanceCalculatorsFactory.Create(starks.Account);
			var lannistersBalanceCalculator = _balanceCalculatorsFactory.Create(lannisters.Account);

			PrintBalance(starks, starksBalanceCalculator);
			PrintBalance(lannisters, lannistersBalanceCalculator);

			Ops(starks, lannisters, 100, Currency.Dragons);

			PrintBalance(starks, starksBalanceCalculator);
			PrintBalance(lannisters, lannistersBalanceCalculator);
		}

		private void Ops(IOwner starks, IOwner lannisters, int amount, Currency currency)
		{
			var transactionCreator = _transactionCreatorsFactory.Create(starks.Account, lannisters.Account);
			transactionCreator.Create(currency, amount, "Pwned by Lannisters");

			Console.WriteLine("{0} has taken {1} {2} from {3}\n", lannisters.Title, amount, currency, starks.Title);
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