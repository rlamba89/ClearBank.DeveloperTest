namespace ClearBank.DeveloperTest.Domain.Account
{
    public class ChapsScheme : PaymentScheme
    {
        public ChapsScheme() : base(nameof(Chaps), 3)
        {
        }

        public override bool IsAccountInValidState(Account account)
        {
            if (account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) &&
                account.Status == AccountStatus.Live)
            {
                return true;
            }
            return false;
        }
    }
}
