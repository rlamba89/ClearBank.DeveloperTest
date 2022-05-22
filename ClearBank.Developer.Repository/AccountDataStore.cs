using ClearBank.DeveloperTest.Domain.Account;
using ClearBank.DeveloperTest.Domain.Repository;

namespace ClearBank.Developer.Repository
{
    public class AccountDataStore :IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account("123455", 100, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments);
        }

        public bool UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
            return true;
        }
    }
}
