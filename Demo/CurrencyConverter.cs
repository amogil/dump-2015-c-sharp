using System;
using System.Collections.Generic;
using System.Linq;

namespace Dump2015.Demo
{
	public interface ICurrencyConverter
	{
		decimal Convert(Currency from, Currency to, decimal amount);
	}

	public class CurrencyConverter : ICurrencyConverter
	{
		private static readonly List<Tuple<Currency, Currency, decimal>> DragonExchangeRates = new List
			<Tuple<Currency, Currency, decimal>>
		{
			Tuple.Create(Currency.Dragons, Currency.Dragons, 1m),
			Tuple.Create(Currency.Dragons, Currency.Stags, 8.1m),
			Tuple.Create(Currency.Dragons, Currency.Groats, 121.4m),
			Tuple.Create(Currency.Dragons, Currency.Pennies, 268m),
		};

		public decimal Convert(Currency from, Currency to, decimal amount)
		{
			var fromRate = DragonExchangeRates.First(tuple => tuple.Item2 == from);
			var toRate = DragonExchangeRates.First(tuple => tuple.Item2 == to);

			return toRate.Item3*amount/fromRate.Item3;
		}
	}
}