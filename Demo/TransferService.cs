namespace Dump2015.Demo
{
	public interface ITransferService
	{
		void Transfer(IAccount from, IAccount to, Money money, string comment);
	}

	public class TransferService : ITransferService
	{
		private readonly ICurrencyConverter _currencyConverter;

		public TransferService(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public void Transfer(IAccount from, IAccount to, Money money, string comment)
		{
			var minus = _currencyConverter.Convert(money, from.Currency);
			var plus = _currencyConverter.Convert(money, to.Currency);
			var t1 = new Transaction(from, -minus.Amount, comment);
			var t2 = new Transaction(to, plus.Amount, comment);
			from.AddTransaction(t1);
			to.AddTransaction(t2);
		}
	}
}