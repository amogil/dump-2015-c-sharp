﻿using System;

namespace Dump2015.Demo
{
	public interface ITransferService
	{
		Tuple<ITransaction, ITransaction> Transfer(IAccount from, IAccount to, Money money, string comment);
	}

	public class TransferService : ITransferService
	{
		private readonly ICurrencyConverter _currencyConverter;

		public TransferService(ICurrencyConverter currencyConverter)
		{
			_currencyConverter = currencyConverter;
		}

		public Tuple<ITransaction, ITransaction> Transfer(IAccount from, IAccount to, Money money, string comment)
		{
			var minus = _currencyConverter.Convert(money, from.Currency);
			var plus = _currencyConverter.Convert(money, to.Currency);
			ITransaction t1 = new Transaction(from, -minus.Amount, comment);
			ITransaction t2 = new Transaction(to, plus.Amount, comment);
			t1.AssignReference(t2);
			t2.AssignReference(t1);
			from.AddTransaction(t1);
			to.AddTransaction(t2);
			return Tuple.Create(t1, t2);
		}
	}
}