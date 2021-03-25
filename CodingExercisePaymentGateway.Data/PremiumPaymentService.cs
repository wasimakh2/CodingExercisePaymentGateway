using CodingExercisePaymentGateway.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.Data
{
    public class PremiumPaymentService
    {
        private Payment payment;
        private readonly Random _random = new Random();

        public PremiumPaymentService(Payment payment)
        {
            this.payment = payment;
        }



        public PaymentState ProcessPayment()
        {


            PaymentState paymentState = new PaymentState();

            int num = _random.Next(1, 3);//This is only for Simulation of Payment Status

            switch (num)
            {
                case 1:
                    paymentState.PaymentProcessStatus = Standard.PaymentProcessStatus.PaymentStatus.Pending;
                    break;
                case 2:
                    paymentState.PaymentProcessStatus = Standard.PaymentProcessStatus.PaymentStatus.Processed;
                    break;
                default:
                    paymentState.PaymentProcessStatus = Standard.PaymentProcessStatus.PaymentStatus.Failed;
                    break;
            }


            return paymentState;



        }
    }
}
