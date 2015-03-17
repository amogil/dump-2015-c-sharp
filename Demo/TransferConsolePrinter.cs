using System;

namespace Dump2015.Demo
{
	internal interface ITransferConsolePrinter
	{
		void Print(IOwner from, IOwner to, Money money);
	}

	internal class TransferConsolePrinter : ITransferConsolePrinter
	{
		public void Print(IOwner from, IOwner to, Money money)
		{
			Console.WriteLine("{0} has taken {1} {2} from {3}\n", to.Title, money.Amount, money.Currency, from.Title);
		}
	}
}