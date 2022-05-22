namespace ClearBank.DeveloperTest.Domain.Account
{
    public class FastPaymentScheme : PaymentScheme
    {
        public FastPaymentScheme() : base(nameof(FasterPayments), 1)
        {
        }

        public override bool IsAccountInValidState(Account account)
        {
            if (account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return true;
            }
            return false;
        }
    }
}
