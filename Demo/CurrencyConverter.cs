using System.Collections.Generic;

namespace Dump2015.Demo
{
	public interface ICurrencyConverter
	{
		decimal Convert(Currency from, Currency to, decimal amount);
	}

	public class CurrencyConverter : ICurrencyConverter
	{
		private static readonly Dictionary<Currency, decimal> DragonExchangeRates = new Dictionary<Currency, decimal>
		{
			{Currency.Dragons, 1m},
			{Currency.Stags, 8.1m},
			{Currency.Groats, 121.4m},
			{Currency.Pennies, 268m},
		};

		public decimal Convert(Currency from, Currency to, decimal amount)
		{
			var fromRate = DragonExchangeRates[from];
			var toRate = DragonExchangeRates[to];

			return toRate*amount/fromRate;
		}
	}
}