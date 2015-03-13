using System;

namespace Dump2015.Demo
{
	internal class Program
	{
		private static void Main()
		{
			// Pretend we are DI container
			var demo = new Demo(new OwnerFactory(), new BalanceCalculatorFactory(),
				new TransactionCreatorFactory(new CurrencyConverter()));

			demo.Show();

			Console.ReadKey();
		}
	}
}