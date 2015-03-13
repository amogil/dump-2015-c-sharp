using System.Linq;

namespace Dump2015.Demo
{
	public interface IBalanceCalculator
	{
		Currency Currency { get; }
		decimal GetBalance();
	}

	public class BalanceCalculator : IBalanceCalculator
	{
		private readonly IAccount _account;

		public BalanceCalculator(IAccount account)
		{
			_account = account;
		}

		public decimal GetBalance()
		{
			return _account.InitialBalance + _account.Transactions.Sum(transaction => transaction.Amount);
		}

		public Currency Currency
		{
			get { return _account.Currency; }
		}
	}
}