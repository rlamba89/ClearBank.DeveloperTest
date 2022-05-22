using ClearBank.DeveloperTest.Domain.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Domain.Tests
{
    [TestClass]
    public class ChapsSchemeDomainTests
    {
        private ChapsScheme _chapsScheme;

        [TestInitialize]
        public void Initialize()
        {
            _chapsScheme = new ChapsScheme();
        }

        [TestMethod]
        public void IsAccountInValidState_ForInvalidAccount_ShouldReturnFalse()
        {
            Assert.IsFalse(_chapsScheme.IsAccountInValidState(null));
        }

        [TestMethod]
        public void IsAccountInValidState_ForNonAllowedPaymentSchemes_ShouldReturnFalse()
        {
            Assert.IsFalse(_chapsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments)));
            Assert.IsFalse(_chapsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Bacs)));
        }

        [TestMethod]
        public void IsAccountInValidState_ForNonLiveAccount_ShouldReturnFalse()
        {
            Assert.IsFalse(_chapsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Disabled, AllowedPaymentSchemes.Chaps)));
            Assert.IsFalse(_chapsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.Chaps)));
        }

        [TestMethod]
        public void IsAccountInValidState_ForValidArgs_ShouldReturnTrue()
        {
            Assert.IsTrue(_chapsScheme.IsAccountInValidState(new Account.Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Chaps)));
        }
    }
}
