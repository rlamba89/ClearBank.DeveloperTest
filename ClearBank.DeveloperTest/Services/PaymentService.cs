using ClearBank.DeveloperTest.Domain.Account.Exceptions;
using ClearBank.DeveloperTest.Domain.IRepository;
using ClearBank.DeveloperTest.Services.Dtos;

namespace ClearBank.DeveloperTest.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;
        public PaymentService(IAccountDataStore accountDataStore)
        {
            _accountDataStore = accountDataStore;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            bool result = false;

            try
            {
                var account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

                if (account != null)
                {
                    account.Debit(request.PaymentScheme, request.Amount);

                    result = _accountDataStore.UpdateAccount(account);
                }
            }
            catch (InvalidAccountNumberException)
            {
                //Log exception
                result = false;
            }
            catch (InValidPaymentSchemeException)
            {
                //Log exception
                result = false;
            }
            catch (InvalidDebitAmountException)
            {
                //Log exception
                result = false;
            }
            catch (InsufficientFundsInAccountException)
            {
                //Log exception
                result = false;
            }

            return new MakePaymentResult
            {
                Success = result
            };
        }
    }
}
