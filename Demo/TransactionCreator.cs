using System;

namespace Dump2015.Demo
{
	public interface ITransactionCreator
	{
		Tuple<ITransaction, ITransaction> Create(Currency currency, decimal amount, string comment);
	}

	public class TransactionCreator : ITransactionCreator
	{
		private readonly ICurrencyConverter _currencyConverter;
		private readonly IAccount _from;
		private readonly IAccount _to;

		public TransactionCreator(IAccount from, IAccount to, ICurrencyConverter currencyConverter)
		{
			_from = from;
			_to = to;
			_currencyConverter = currencyConverter;
		}

		public Tuple<ITransaction, ITransaction> Create(Currency currency, decimal amount, string comment)
		{
			var minusAmount = _currencyConverter.Convert(currency, _from.Currency, amount);
			var plusAmount = _currencyConverter.Convert(currency, _to.Currency, amount);
			ITransaction t1 = new Transaction(_from, -minusAmount, comment);
			ITransaction t2 = new Transaction(_to, plusAmount, comment);
			t1.AssignReference(t2);
			t2.AssignReference(t1);
			_from.AddTransaction(t1);
			_to.AddTransaction(t2);
			return Tuple.Create(t1, t2);
		}
	}
}