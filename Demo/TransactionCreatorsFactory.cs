namespace Dump2015.Demo
{
	public interface ITransactionCreatorsFactory
	{
		ITransactionCreator Create(IAccount from, IAccount to);
	}

	public class TransactionCreatorsFactory : ITransactionCreatorsFactory
	{
		private readonly ICurrencyConverter _currencyConverter;

		public TransactionCreatorsFactory(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public ITransactionCreator Create(IAccount from, IAccount to)
		{
			return new TransactionCreator(from, to, _currencyConverter);
		}
	}
}