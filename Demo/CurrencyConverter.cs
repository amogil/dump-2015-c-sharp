using System.Collections.Generic;

namespace Dump2015.Demo
{
	public interface ICurrencyConverter
	{
		decimal Convert(Currency from, Currency to, decimal amount);
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

		public decimal Convert(Currency from, Currency to, decimal amount)
		{
			var fromRate = DragonExchangeRates[from];
			var toRate = DragonExchangeRates[to];

			return toRate*amount/fromRate;
		}

		public Money Convert(Money money, Currency to)
		{
			var amount = Convert(money.Currency, to, money.Amount);
			return new Money(amount, to);
		}
	}
}