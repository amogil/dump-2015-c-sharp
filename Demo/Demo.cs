namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IBalanceCalculatorsFactory _balanceCalculatorsFactory;
		private readonly IBalanceConsolePrinter _balanceConsolePrinter;
		private readonly IOwnersRepository _ownersRepository;
		private readonly ITransferConsolePrinter _transferConsolePrinter;
		private readonly ITransferService _transferService;

		public Demo(IOwnersRepository ownersRepository, IBalanceCalculatorsFactory balanceCalculatorsFactory,
			ITransferService transferService, IBalanceConsolePrinter balanceConsolePrinter,
			ITransferConsolePrinter transferConsolePrinter)
		{
			_ownersRepository = ownersRepository;
			_balanceCalculatorsFactory = balanceCalculatorsFactory;
			_transferService = transferService;
			_balanceConsolePrinter = balanceConsolePrinter;
			_transferConsolePrinter = transferConsolePrinter;
		}

		public void Show()
		{
			var starksInitMoney = new Money(1500, Currency.Stags);
			var lannistersInitMoney = new Money(9999, Currency.Dragons);
			var starks = _ownersRepository.CreateNew("House Stark", "Winterfell", "Winter is Coming", starksInitMoney);
			var lannisters = _ownersRepository.CreateNew("House Lannister", "Casterly Rock", "Hear Me Roar!", lannistersInitMoney);

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