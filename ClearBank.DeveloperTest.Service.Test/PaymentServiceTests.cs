using ClearBank.DeveloperTest.Domain.Account;
using ClearBank.DeveloperTest.Domain.Repository;
using ClearBank.DeveloperTest.Services.Dtos;
using ClearBank.DeveloperTest.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ClearBank.DeveloperTest.Services.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {
        private IPaymentService _paymentService;
        private Mock<IAccountDataStore> _accountDataStore;
        private Account _account;

        [TestInitialize]
        public void Initialize()
        {
            _accountDataStore = new Mock<IAccountDataStore>();
            _account = new Account("5555", 1000, AccountStatus.Live, AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps | AllowedPaymentSchemes.FasterPayments);
            _paymentService = new PaymentService(_accountDataStore.Object);
        }

        [TestMethod]
        public void MakePayment_ForValidAccount_ShouldReturnTrue()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = _account.AccountNumber,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            };

            _accountDataStore.Setup(a => a.GetAccount(request.DebtorAccountNumber)).Returns(_account);
            _accountDataStore.Setup(a => a.UpdateAccount(_account)).Returns(true);

            //Act
            var actual = _paymentService.MakePayment(request);

            //Assert
            Assert.IsTrue(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.Is<Account>(a => a.Balance == 900 && a.AccountNumber == _account.AccountNumber
               && a.Status == _account.Status && a.AllowedPaymentSchemes == _account.AllowedPaymentSchemes)), Times.Once);
        }

        [TestMethod]
        public void MakePayment_ForInvalidDebtorAccountNumber_ShouldReturnFalse()
        {
            //Arrange
            _accountDataStore.Setup(a => a.GetAccount(It.IsAny<string>())).Returns(() => null);

            //Act
            var actual = _paymentService.MakePayment(new MakePaymentRequest
            {
                Amount = 100,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = _account.AccountNumber,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            });

            //Assert
            Assert.IsFalse(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_ForAFailedAccountUpdate_ShoulsReturnFalse()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = _account.AccountNumber,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            };

            _accountDataStore.Setup(a => a.GetAccount(request.DebtorAccountNumber)).Returns(_account);
            _accountDataStore.Setup(a => a.UpdateAccount(_account)).Returns(false);

            //Act
            var actual = _paymentService.MakePayment(request);

            //Assert
            Assert.IsFalse(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.Is<Account>(a => a.Balance == 900 && a.AccountNumber == _account.AccountNumber
               && a.Status == _account.Status && a.AllowedPaymentSchemes == _account.AllowedPaymentSchemes)), Times.Once);
        }

        [TestMethod]
        public void MakePayment_ForInValidPaymentSchemeException_ShouldReturnFalse()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 100,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = "33333",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Chaps
            };

            _accountDataStore.Setup(a => a.GetAccount(request.DebtorAccountNumber)).Returns(new Account("5555", 1000, AccountStatus.Live, AllowedPaymentSchemes.Bacs));

            //Act
            var actual = _paymentService.MakePayment(request);

            //Assert
            Assert.IsFalse(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_ForInvalidDebitAmountException_ShouldReturnFalse()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = -10,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = _account.AccountNumber,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Chaps
            };

            _accountDataStore.Setup(a => a.GetAccount(request.DebtorAccountNumber)).Returns(_account);

            //Act
            var actual = _paymentService.MakePayment(request);

            //Assert
            Assert.IsFalse(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_ForInsufficientFundsInAccountException_ShouldReturnFalse()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = _account.Balance + 1,
                CreditorAccountNumber = "1234",
                DebtorAccountNumber = _account.AccountNumber,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Chaps
            };

            _accountDataStore.Setup(a => a.GetAccount(request.DebtorAccountNumber)).Returns(_account);

            //Act
            var actual = _paymentService.MakePayment(request);

            //Assert
            Assert.IsFalse(actual.Success);
            _accountDataStore.Verify(a => a.UpdateAccount(It.IsAny<Account>()), Times.Never);
        }
    }
}
