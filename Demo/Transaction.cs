using System;

namespace Dump2015.Demo
{
	public interface ITransaction
	{
		string Id { get; }
		IAccount Account { get; }
		decimal Amount { get; }
		ITransaction Reference { get; }
		string Comment { get; }
	}

	public class Transaction : ITransaction
	{
		public Transaction(IAccount account, decimal amount, string comment)
		{
			Id = Guid.NewGuid().ToString();
			Comment = comment;
			Amount = amount;
			Account = account;
		}

		public string Id { get; private set; }
		public IAccount Account { get; private set; }
		public decimal Amount { get; private set; }
		public ITransaction Reference { get; private set; }
		public string Comment { get; private set; }
	}
}