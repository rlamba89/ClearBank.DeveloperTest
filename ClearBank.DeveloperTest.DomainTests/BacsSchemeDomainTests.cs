using ClearBank.DeveloperTest.Domain.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Domain.Tests
{
    [TestClass]
    public class BacsSchemeDomainTests
    {
        private BacsScheme _bacsScheme;

        [TestInitialize]
        public void Initalize()
        {
            _bacsScheme = new BacsScheme();
        }

        [TestMethod]
        public void IsAccountInValidState_ForInvalidAccount_ShouldReturnFalse()
        {
            Assert.IsFalse(_bacsScheme.IsAccountInValidState(null));
        }

        [TestMethod]
        public void IsAccountInValidState_ForNonAllowedPaymentSchemes_ShouldReturnFalse()
        {
            Assert.IsFalse(_bacsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments)));
            Assert.IsFalse(_bacsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Chaps)));
        }

        [TestMethod]
        public void IsAccountInValidState_ForValidArgs_ShouldReturnTrue()
        {
            Assert.IsTrue(_bacsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Bacs)));
        }
    }
}
