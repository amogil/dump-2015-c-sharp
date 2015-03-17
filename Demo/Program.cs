using System;

namespace Dump2015.Demo
{
	internal class Program
	{
		private static void Main()
		{
			// Pretend we are DI-container
			var demo = new Demo(new OwnersRepository(), new BalanceCalculatorsFactory(),
				new TransferService(new CurrencyConverter()), new BalanceConsolePrinter(), new TransferConsolePrinter());

			demo.Show();

			Console.ReadKey();
		}
	}
}