using System;

namespace Dump2015.Demo
{
	internal interface ITransferConsolePrinter
	{
		void Print(IOwner from, IOwner to, int amount, Currency currency);
	}

	internal class TransferConsolePrinter : ITransferConsolePrinter
	{
		public void Print(IOwner from, IOwner to, int amount, Currency currency)
		{
			Console.WriteLine("{0} has taken {1} {2} from {3}\n", to.Title, amount, currency, from.Title);
		}
	}
}