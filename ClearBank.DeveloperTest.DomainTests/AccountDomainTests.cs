using ClearBank.DeveloperTest.Domain.Account;
using ClearBank.DeveloperTest.Domain.Account.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClearBank.DeveloperTest.DomainTests
{
    [TestClass]
    public class AccountDomainTests
    {
        private Account _account;

        [TestInitialize]
        public void Initialize()
        {
            _account = new Account("3030303", 500, AccountStatus.Live, AllowedPaymentSchemes.Bacs);
        }

        [TestMethod]
        public void Constructor_ForValidArgs_ShouldSetAccount()
        {
            var account = new Account("44444", 100, AccountStatus.Live, AllowedPaymentSchemes.Chaps);

            Assert.AreEqual("44444", account.AccountNumber);
            Assert.AreEqual(100, account.Balance);
            Assert.AreEqual(AccountStatus.Live, account.Status);
            Assert.AreEqual(AllowedPaymentSchemes.Chaps, account.AllowedPaymentSchemes);
        }

        [DataRow("")]
        [DataRow("  ")]
        [DataRow(null)]
        [DataTestMethod]
        public void Constructor_ForInvalidAccountNumber_ShouldThrowInvalidAccountNumberException(string accountNumber)
        {
            Assert.ThrowsException<InvalidAccountNumberException>(() => new Account(accountNumber, 100, AccountStatus.Live, AllowedPaymentSchemes.Bacs));
        }

        [DataRow("0")]
        [DataRow("-10")]
        [DataTestMethod]
        public void Debit_ForInvalidDebitAmount_ShouldThrowInvalidDebitAmount(string debitAmount)
        {
            Assert.ThrowsException<InvalidDebitAmountException>(() => _account.Debit(PaymentScheme.Bacs, Convert.ToDecimal(debitAmount)));
        }

        [DataRow("1000")]
        [DataRow("501")]
        [DataTestMethod]
        public void Debit_ForInsufficientFunds_ShouldThrowInsufficientFundsInAccountException(string debitAmount)
        {
            Assert.ThrowsException<InsufficientFundsInAccountException>(() => _account.Debit(PaymentScheme.Bacs, Convert.ToDecimal(debitAmount)));
        }


        [TestMethod]
        public void Debit_ForInvalidPaymentScheme_ShouldThrowInValidPaymentSchemeException()
        {
            Assert.ThrowsException<InValidPaymentSchemeException>(() => _account.Debit(PaymentScheme.Chaps, 100.0m));
            Assert.ThrowsException<InValidPaymentSchemeException>(() => _account.Debit(PaymentScheme.FasterPayments, 100.0m));

            Assert.AreEqual(500, _account.Balance);
        }

        [TestMethod]
        public void Debit_ForValidArgs_ShouldDebitTheAmount()
        {
            _account.Debit(PaymentScheme.Bacs, 100.0m);

            Assert.AreEqual(400, _account.Balance);
        }
    }
}
