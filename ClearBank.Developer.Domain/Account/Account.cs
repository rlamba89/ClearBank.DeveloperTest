using ClearBank.DeveloperTest.Domain.Account.Exceptions;

namespace ClearBank.DeveloperTest.Domain.Account
{
    public class Account
    {
        public Account(string accountNumber, decimal balance, AccountStatus status, AllowedPaymentSchemes allowedPaymentSchemes)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new InvalidAccountNumberException("Invalid account number");
            
            AccountNumber = accountNumber;
            Balance = balance;
            Status = status;
            AllowedPaymentSchemes = allowedPaymentSchemes;
        }

        public string AccountNumber { get; private set; }

        public decimal Balance { get; private set; }

        public AccountStatus Status { get; private set; }

        public AllowedPaymentSchemes AllowedPaymentSchemes { get; private set; }

        public void Debit(PaymentScheme scheme, decimal debitAmount)
        {
            var isValid = scheme.IsAccountInValidState(this);

            if (!isValid) throw new InValidPaymentSchemeException();

            if (debitAmount <= 0) throw new InvalidDebitAmountException("Invalid debit amount");
            
            if (Balance < debitAmount) throw new InsufficientFundsInAccountException();

            Balance -= debitAmount;
        }
    }
}
