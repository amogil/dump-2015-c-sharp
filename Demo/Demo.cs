namespace Dump2015.Demo
{
	internal class Demo
	{
		private readonly IOwnersRepository _ownersRepository;
		private readonly IReceiptConsolePrinter _receiptConsolePrinter;
		private readonly ITransferService _transferService;

		public Demo(IOwnersRepository ownersRepository, ITransferService transferService,
			IReceiptConsolePrinter receiptConsolePrinter)
		{
			_ownersRepository = ownersRepository;
			_transferService = transferService;
			_receiptConsolePrinter = receiptConsolePrinter;
		}

		public void Show()
		{
			var starksInitMoney = new Money(1500, Currency.Stags);
			var lannistersInitMoney = new Money(9999, Currency.Dragons);
			var starks = _ownersRepository.CreateNew("House Stark", "Winterfell", "Winter is Coming", starksInitMoney);
			var lannisters = _ownersRepository.CreateNew("House Lannister", "Casterly Rock", "Hear Me Roar!", lannistersInitMoney);

			_receiptConsolePrinter.Print(starks);
			_receiptConsolePrinter.Print(lannisters);

			var money = new Money(100, Currency.Dragons);
			_transferService.Transfer(starks.Account, lannisters.Account, money, "Pwned by Lannisters");

			_receiptConsolePrinter.Print(starks);
			_receiptConsolePrinter.Print(lannisters);
		}
	}
}