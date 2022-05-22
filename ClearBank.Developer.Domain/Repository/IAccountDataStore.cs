namespace ClearBank.DeveloperTest.Domain.Repository
{
    public interface IAccountDataStore
    {
        Account.Account GetAccount(string accountNumber);

        bool UpdateAccount(Account.Account account);
    }
}
