using System;

namespace Dump2015.Demo
{
	public interface IOwnerFactory
	{
		IOwner Create(string title, string castle, string words, Currency currency);
	}

	public class OwnerFactory : IOwnerFactory
	{
		private readonly Random _random = new Random();

		public IOwner Create(string title, string castle, string words, Currency currency)
		{
			var initialBalance = Convert.ToDecimal(Math.Round(_random.NextDouble()*10000));
			var account = new Account(currency, initialBalance);
			return new Owner(title, castle, words, account);
		}
	}
}