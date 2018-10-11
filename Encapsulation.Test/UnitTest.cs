using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encapsulation.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void OrderProcessorIsFast()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var order = new Order();

            var validator = new Mock<IOrderValidator>();
            validator.Setup(src => src.Validate(order)).Returns(false);

            var shipper = new OrderShipper();
            var orderProcessor = new OrderProcessor(validator.Object, shipper);
            orderProcessor.Process(order);
            
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromMilliseconds(777));
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
