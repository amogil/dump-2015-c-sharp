using System;
using System.Linq;

namespace Dump2015.Demo
{
	public interface IKingsMentalStateCalculator
	{
		int GetEnvy(IOwner owner);
	}

	public class KingsMentalStateCalculator : IKingsMentalStateCalculator
	{
		private const decimal KingsEnvyThresholdGroats = 100;
		private const decimal KingsGrace = 1000;
		private readonly ICurrencyConverter _currencyConverter;

		public KingsMentalStateCalculator(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public int GetEnvy(IOwner owner)
		{
			var balance = owner.Account.GetBalance();
			var balanceInGroats = _currencyConverter.Convert(balance.Currency, Currency.Groats, balance.Amount);
			var incomesWithoutTrash = owner.Account.Transactions
				.Select(t => _currencyConverter.Convert(owner.Account.Currency, Currency.Groats, t.Amount))
				.Where(amount => amount > KingsEnvyThresholdGroats);
			var transactionsCountToEnvy = incomesWithoutTrash.Count();
			if (transactionsCountToEnvy == 0) transactionsCountToEnvy = 1;
			var envy = balanceInGroats/(transactionsCountToEnvy*KingsGrace);
			return Convert.ToInt32(envy);
		}
	}
}