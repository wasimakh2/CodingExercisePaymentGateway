using CodingExercisePaymentGateway.Data.Models;

namespace CodingExercisePaymentGateway.Data
{
    public interface ICheapPaymentGateway
    {
        PaymentState ProcessPayment();
    }
}