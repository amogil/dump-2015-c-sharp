namespace Dump2015.Demo
{
	public interface IBalanceCalculatorFactory
	{
		IBalanceCalculator Create(IAccount account);
	}

	public class BalanceCalculatorFactory : IBalanceCalculatorFactory
	{
		public IBalanceCalculator Create(IAccount account)
		{
			return new BalanceCalculator(account);
		}
	}
}