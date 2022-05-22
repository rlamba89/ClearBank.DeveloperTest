using Ardalis.SmartEnum.JsonNet;
using ClearBank.DeveloperTest.Domain.Account;
using System;
using System.Text.Json.Serialization;

namespace ClearBank.DeveloperTest.Services.Dtos
{
    public class MakePaymentRequest
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [JsonConverter(typeof(SmartEnumValueConverter<PaymentScheme, int>))]
        public PaymentScheme PaymentScheme { get; set; }
    }
}
