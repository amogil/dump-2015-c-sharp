namespace Dump2015.Demo
{
	public interface IOwnersRepository
	{
		IOwner CreateNew(string title, string castle, string words, Money initBalance);
	}

	public class OwnersRepository : IOwnersRepository
	{
		public IOwner CreateNew(string title, string castle, string words, Money initBalance)
		{
			var account = new Account(initBalance.Currency, initBalance.Amount);
			var owner = new Owner(title, castle, words, account);
			// Save to DB
			return owner;
		}
	}
}