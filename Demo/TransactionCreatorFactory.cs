namespace Dump2015.Demo
{
	public interface ITransactionCreatorFactory
	{
		ITransactionCreator Create(IAccount from, IAccount to);
	}

	public class TransactionCreatorFactory : ITransactionCreatorFactory
	{
		private readonly ICurrencyConverter _currencyConverter;

		public TransactionCreatorFactory(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public ITransactionCreator Create(IAccount from, IAccount to)
		{
			return new TransactionCreator(from, to, _currencyConverter);
		}
	}
}