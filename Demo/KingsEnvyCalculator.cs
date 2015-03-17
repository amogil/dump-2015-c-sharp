using System;
using System.Linq;

namespace Dump2015.Demo
{
	public interface IKingsStateCalculator
	{
		int GetEnvy(IOwner owner);
	}

	public class KingsStateCalculator : IKingsStateCalculator
	{
		private const decimal KingsEnvyThresholdGroats = 100;
		private const decimal KingsGrace = 1000;
		private readonly ICurrencyConverter _currencyConverter;

		public KingsStateCalculator(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public int GetEnvy(IOwner owner)
		{
			var balanceInDragons = _currencyConverter.Convert(owner.Account.GetBalance(), Currency.Groats);
			var incomesWithoutTrash = owner.Account.Transactions
				.Select(t => _currencyConverter.Convert(owner.Account.Currency, Currency.Groats, t.Amount))
				.Where(amount => amount > KingsEnvyThresholdGroats);
			var transactionsCountToEnvy = incomesWithoutTrash.Count();
			if (transactionsCountToEnvy == 0) transactionsCountToEnvy = 1;
			var envy = balanceInDragons.Amount/(transactionsCountToEnvy*KingsGrace);
			return Convert.ToInt32(envy);
		}
	}
}