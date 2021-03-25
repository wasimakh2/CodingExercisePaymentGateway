using CodingExercisePaymentGateway.Data.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.Data.Models
{
    public class PaymentState
    {
        public long Id { get; set; }

        public PaymentProcessStatus.PaymentStatus PaymentProcessStatus { get; set; }

    }
}
