using CodingExercisePaymentGateway.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercisePaymentGateway
{
    class PaymentGatewayDBContext:DbContext
    {

        public PaymentGatewayDBContext(DbContextOptions<PaymentGatewayDBContext> options)
            :base(options)
        {

        }

        public DbSet<Payment> payments { get; set; }

    }
}
