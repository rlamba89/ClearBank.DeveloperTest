using ClearBank.DeveloperTest.Domain.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Domain.Tests
{
    [TestClass]
    public class FasterPaymentSchemeDomainTests
    {
        private FastPaymentScheme _fastPaymentScheme;

        [TestInitialize]
        public void Initialize()
        {
            _fastPaymentScheme = new FastPaymentScheme();
        }

        [TestMethod]
        public void IsAccountInValidState_ForInvalidAccount_ShouldReturnFalse()
        {
            Assert.IsFalse(_fastPaymentScheme.IsAccountInValidState(null));
        }

        [TestMethod]
        public void IsAccountInValidState_ForNonAllowedPaymentSchemes_ShouldReturnFalse()
        {
            Assert.IsFalse(_fastPaymentScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Chaps)));
            Assert.IsFalse(_fastPaymentScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Bacs)));
        }

        [TestMethod]
        public void IsAccountInValidState_ForValidArgs_ShouldReturnTrue()
        {
            Assert.IsTrue(_fastPaymentScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments)));
        }
    }
}
