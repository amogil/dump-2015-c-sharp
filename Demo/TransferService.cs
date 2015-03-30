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
			var minusAmount = _currencyConverter.Convert(money.Currency, from.Currency, money.Amount);
			var plusAmount = _currencyConverter.Convert(money.Currency, to.Currency, money.Amount);
			var t1 = new Transaction(from, -minusAmount, comment);
			var t2 = new Transaction(to, plusAmount, comment);
			from.AddTransaction(t1);
			to.AddTransaction(t2);
		}
	}
}