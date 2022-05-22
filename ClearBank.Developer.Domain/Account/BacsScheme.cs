namespace ClearBank.DeveloperTest.Domain.Account
{
    public class BacsScheme : PaymentScheme
    {
        public BacsScheme() : base(nameof(Bacs), 2)
        {
        }

        public override bool IsAccountInValidState(Account account)
        {
            if (account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                return true;
            }
            return false;
        }
    }
}
