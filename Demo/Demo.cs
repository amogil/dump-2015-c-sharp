namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IBalanceCalculatorsFactory _balanceCalculatorsFactory;
		private readonly IBalanceConsolePrinter _balanceConsolePrinter;
		private readonly IOwnersFactory _ownersFactory;
		private readonly ITransferConsolePrinter _transferConsolePrinter;
		private readonly ITransferService _transferService;

		public Demo(IOwnersFactory ownersFactory, IBalanceCalculatorsFactory balanceCalculatorsFactory,
			ITransferService transferService, IBalanceConsolePrinter balanceConsolePrinter,
			ITransferConsolePrinter transferConsolePrinter)
		{
			_ownersFactory = ownersFactory;
			_balanceCalculatorsFactory = balanceCalculatorsFactory;
			_transferService = transferService;
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

			var money = new Money(100, Currency.Dragons);
			_transferService.Transfer(starks.Account, lannisters.Account, money, "Pwned by Lannisters");
			_transferConsolePrinter.Print(starks, lannisters, money);

			_balanceConsolePrinter.Print(starks, starksBalanceCalculator);
			_balanceConsolePrinter.Print(lannisters, lannistersBalanceCalculator);
		}
	}
}