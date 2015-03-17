using System.Linq;

namespace Dump2015.Demo
{
	public interface IBalanceCalculator
	{
		decimal GetBalance(IAccount account);
	}

	public class BalanceCalculator : IBalanceCalculator
	{
		public decimal GetBalance(IAccount account)
		{
			return account.InitialBalance + account.Transactions.Sum(transaction => transaction.Amount);
		}
	}
}