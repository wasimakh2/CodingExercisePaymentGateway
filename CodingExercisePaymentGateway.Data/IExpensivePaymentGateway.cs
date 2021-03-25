using CodingExercisePaymentGateway.Data.Models;

namespace CodingExercisePaymentGateway.Data
{
    public interface IExpensivePaymentGateway
    {
        PaymentState ProcessPayment();
    }
}