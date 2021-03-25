using CodingExercisePaymentGateway.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.Data
{
    public class PaymentService
    {   

        private PaymentGateway paymentGateway;


        public PaymentService()
        {

        }

        public void ProcessPayment(Models.Payment payment)
        {
            paymentGateway = new PaymentGateway(payment);
            if (payment.Amount<20)
            {

                PaymentState paymentState=((ICheapPaymentGateway)paymentGateway).ProcessPayment();

                payment.PaymentState = paymentState;
                
            }
            else if(payment.Amount>20 && payment.Amount<=500)
            {
                PaymentState paymentState = ((IExpensivePaymentGateway)paymentGateway).ProcessPayment();

                if (paymentState.PaymentProcessStatus==Standard.PaymentProcessStatus.PaymentStatus.Failed)
                {
                    paymentState = ((ICheapPaymentGateway)paymentGateway).ProcessPayment();
                }

                payment.PaymentState = paymentState;
            }
            else if(payment.Amount>500)
            {

                PremiumPaymentService premiumPaymentService = new PremiumPaymentService(payment);


                PaymentState paymentState = premiumPaymentService.ProcessPayment();

                if (paymentState.PaymentProcessStatus == Standard.PaymentProcessStatus.PaymentStatus.Failed)
                {
                    int Retry = 0;

                    while (Retry < 2)
                    {
                        if (paymentState.PaymentProcessStatus == Standard.PaymentProcessStatus.PaymentStatus.Failed)
                        {
                            paymentState = premiumPaymentService.ProcessPayment();
                        }

                        Retry++;
                    }
                }

                payment.PaymentState = paymentState;

            }



            
        }
    }
}
