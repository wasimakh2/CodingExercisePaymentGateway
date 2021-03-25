using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public PaymentState PaymentState { get; set; }


    }
}
