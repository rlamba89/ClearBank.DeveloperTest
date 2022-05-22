using ClearBank.DeveloperTest.Domain.Account;
using ClearBank.DeveloperTest.Domain.IRepository;

namespace ClearBank.Developer.Repository
{
    public class BackupAccountDataStore : IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access backup data base to retrieve account, code removed for brevity 
            return new Account("123455", 100, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments);
        }

        public bool UpdateAccount(Account account)
        {
            // Update account in backup database, code removed for brevity
            return true;
        }
    }
}
