namespace Dump2015.Demo
{
	public interface IBalanceCalculatorsFactory
	{
		IBalanceCalculator Create(IAccount account);
	}

	public class BalanceCalculatorsFactory : IBalanceCalculatorsFactory
	{
		public IBalanceCalculator Create(IAccount account)
		{
			return new BalanceCalculator(account);
		}
	}
}