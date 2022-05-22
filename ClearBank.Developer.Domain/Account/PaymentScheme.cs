using Ardalis.SmartEnum;

namespace ClearBank.DeveloperTest.Domain.Account
{
    public abstract partial class PaymentScheme : SmartEnum<PaymentScheme>
    {
        public PaymentScheme(string name, int value) : base(name, value)
        {
        }

        public static readonly PaymentScheme FasterPayments = new FastPaymentScheme();
        public static readonly PaymentScheme Bacs = new BacsScheme();
        public static readonly PaymentScheme Chaps = new ChapsScheme();

        public abstract bool IsAccountInValidState(Account account);

    }
}
