using CodingExercisePaymentGateway;
using CodingExercisePaymentGateway.Data.Models;
using CodingExercisePaymentGateway.Helper;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CodingExercisePaymentGateway.Test.Helper
{
    [TestFixture]
    public class PaymentHelperTests
    {
        private PaymentGatewayDBContext subPaymentGatewayDBContext;

        [SetUp]
        public void SetUp()
        {
            this.subPaymentGatewayDBContext = Substitute.For<PaymentGatewayDBContext>();
            
        }

        private PaymentHelper CreatePaymentHelper()
        {
            return new PaymentHelper(
                this.subPaymentGatewayDBContext);


            
        }

        [Test]
        public void Process_False()
        {
            // Arrange
            var paymentHelper = this.CreatePaymentHelper();
            Payment payment = null;

            // Act
            var result = paymentHelper.Process(
                payment);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Process_True()
        {
            // Arrange
            var paymentHelper = this.CreatePaymentHelper();
            Payment payment = new Payment();

            payment.CreditCardNumber = "4929518484263471";
            payment.CardHolder = "Lauriane McDermott";
            payment.ExpirationDate = DateTime.Now;
            payment.SecurityCode = "567";
            payment.Amount = 100.00M;

            // Act
            var result = paymentHelper.Process(
                payment);

            // Assert
            Assert.IsTrue(result.PaymentProcessStatus==Data.Standard.PaymentProcessStatus.PaymentStatus.Processed);
        }

        

        
    }
}
