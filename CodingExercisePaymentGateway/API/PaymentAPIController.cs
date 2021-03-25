using CodingExercisePaymentGateway.Data.Models;
using CodingExercisePaymentGateway.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentAPIController : ControllerBase
    {
        private readonly PaymentGatewayDBContext _context;

        public PaymentAPIController(PaymentGatewayDBContext context)
        {
            _context = context;
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            try
            {
                PaymentHelper paymentHelper = new PaymentHelper(_context);

                if (payment.SecurityCode==null)
                {
                    payment.SecurityCode = "000";
                }

                if (paymentHelper.Validatated(payment)==false)
                {
                    return StatusCode(400);
                }


                var paymentState = paymentHelper.Process(payment);

                if (paymentState.PaymentProcessStatus == Data.Standard.PaymentProcessStatus.PaymentStatus.Processed)
                {
                    return Ok();
                }




            }
            catch (Exception ex)
            {

                return StatusCode(500); 
            }


            return StatusCode(500);

        }
    }
}
