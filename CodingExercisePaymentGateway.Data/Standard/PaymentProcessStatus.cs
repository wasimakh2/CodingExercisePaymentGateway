using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.Data.Standard
{
    public class PaymentProcessStatus
    {
        public enum PaymentStatus
        {
            Pending,
            Processed,
            Failed
        }
    }
}
