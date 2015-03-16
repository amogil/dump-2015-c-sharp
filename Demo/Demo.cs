namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IBalanceCalculatorsFactory _balanceCalculatorsFactory;
		private readonly IBalanceConsolePrinter _balanceConsolePrinter;
		private readonly IOwnersFactory _ownersFactory;
		private readonly ITransactionCreatorsFactory _transactionCreatorsFactory;
		private readonly ITransferConsolePrinter _transferConsolePrinter;

		public Demo(IOwnersFactory ownersFactory, IBalanceCalculatorsFactory balanceCalculatorsFactory,
			ITransactionCreatorsFactory transactionCreatorsFactory, IBalanceConsolePrinter balanceConsolePrinter,
			ITransferConsolePrinter transferConsolePrinter)
		{
			_ownersFactory = ownersFactory;
			_balanceCalculatorsFactory = balanceCalculatorsFactory;
			_transactionCreatorsFactory = transactionCreatorsFactory;
			_balanceConsolePrinter = balanceConsolePrinter;
			_transferConsolePrinter = transferConsolePrinter;
		}

		public void Show()
		{
			var starks = _ownersFactory.Create("House Stark", "Winterfell", "Winter is Coming", Currency.Stags);
			var lannisters = _ownersFactory.Create("House Lannister", "Casterly Rock", "Hear Me Roar!", Currency.Dragons);

			var starksBalanceCalculator = _balanceCalculatorsFactory.Create(starks.Account);
			var lannistersBalanceCalculator = _balanceCalculatorsFactory.Create(lannisters.Account);

			_balanceConsolePrinter.Print(starks, starksBalanceCalculator);
			_balanceConsolePrinter.Print(lannisters, lannistersBalanceCalculator);

			Transfer(starks, lannisters, 100, Currency.Dragons);

			_balanceConsolePrinter.Print(starks, starksBalanceCalculator);
			_balanceConsolePrinter.Print(lannisters, lannistersBalanceCalculator);
		}

		private void Transfer(IOwner starks, IOwner lannisters, int amount, Currency currency)
		{
			var transactionCreator = _transactionCreatorsFactory.Create(starks.Account, lannisters.Account);
			transactionCreator.Create(currency, amount, "Pwned by Lannisters");

			_transferConsolePrinter.Print(starks, lannisters, amount, currency);
		}
	}
}