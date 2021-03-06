﻿namespace Dump2015.Demo
{
	public interface IOwner
	{
		string Title { get; }
		string Words { get; }
		string Castle { get; }
		IAccount Account { get; }
	}

	public class Owner : IOwner
	{
		public Owner(string title, string castle, string words, Money initBalance)
		{
			Title = title;
			Castle = castle;
			Words = words;
			Account = new Account(initBalance.Currency, initBalance.Amount);
		}

		public IAccount Account { get; set; }

		public string Title { get; private set; }
		public string Words { get; private set; }
		public string Castle { get; private set; }
	}
}