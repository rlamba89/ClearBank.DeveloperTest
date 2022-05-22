using ClearBank.DeveloperTest.Services.Dtos;

namespace ClearBank.DeveloperTest.Services.Services
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
