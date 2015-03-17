using System;

namespace Dump2015.Demo
{
	internal class Program
	{
		private static void Main()
		{
			// Pretend we are DI-container
			var currencyConverter = new CurrencyConverter();
			var demo = new Demo(new OwnersRepository(), new TransferService(currencyConverter),
				new ReceiptConsolePrinter(new KingsStateCalculator(currencyConverter)),
				new TransferConsolePrinter());

			demo.Show();

			Console.ReadKey();
		}
	}
}