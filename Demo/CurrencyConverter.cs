using System.Collections.Generic;

namespace Dump2015.Demo
{
	public interface ICurrencyConverter
	{
		Money Convert(Money money, Currency to);
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

		public Money Convert(Money money, Currency to)
		{
			var fromRate = DragonExchangeRates[money.Currency];
			var toRate = DragonExchangeRates[to];

			return new Money(toRate*money.Amount/fromRate, to);
		}
	}
}