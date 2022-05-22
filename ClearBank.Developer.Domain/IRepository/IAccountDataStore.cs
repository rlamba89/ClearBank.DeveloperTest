namespace ClearBank.DeveloperTest.Domain.IRepository
{
    public interface IAccountDataStore
    {
        Account.Account GetAccount(string accountNumber);

        bool UpdateAccount(Account.Account account);
    }
}
