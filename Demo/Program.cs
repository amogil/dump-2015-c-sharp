using System;

namespace Dump2015.Demo
{
	internal class Program
	{
		private static void Main()
		{
			// Pretend we are DI-container
			var currencyConverter = new CurrencyConverter();
			var demo = new Demo(new TransferService(currencyConverter),
				new ReceiptConsolePrinter(new KingsMentalStateCalculator(currencyConverter)));

			demo.Show();

			Console.ReadKey();
		}
	}
}