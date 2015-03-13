using System;
using System.Collections.Generic;
using System.Linq;

namespace Dump2015.Demo
{
	public interface IAccount
	{
		string Id { get; }
		Currency Currency { get; }
		IEnumerable<ITransaction> Transactions { get; }
		decimal InitialBalance { get; }
		void AddTransaction(ITransaction transaction);
	}

	public class Account : IAccount
	{
		private readonly List<ITransaction> _transactions;

		public Account(Currency currency, decimal initialBalance)
		{
			Id = Guid.NewGuid().ToString();
			Currency = currency;
			InitialBalance = initialBalance;
			_transactions = new List<ITransaction>();
		}

		public string Id { get; private set; }
		public Currency Currency { get; private set; }
		public decimal InitialBalance { get; private set; }

		public IEnumerable<ITransaction> Transactions
		{
			get { return _transactions; }
		}

		public void AddTransaction(ITransaction transaction)
		{
			if (_transactions.Any(t => t.Id == transaction.Id))
				throw new ApplicationException("Hodor?");
			if (transaction.Account != this)
				throw new ApplicationException("Hodor!");
			_transactions.Add(transaction);
		}
	}
}