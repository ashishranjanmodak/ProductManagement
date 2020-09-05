using NUnit.Framework;
using NUnit.Framework.Constraints;
using ProductPromotionEngine.Models;
using ProductPromotionsHandler.Models;
using System.Collections.Generic;

namespace ProductPromotionEngine.Test
{
    [TestFixture]
    public class PromotionEngineTest
    {
        private OrderDetails OrderDetails;
        private static Dictionary<string, int> test1;
        private static Dictionary<string, int> test2;
        private static Dictionary<string, int> test3;

        [SetUp]
        public void setup()
        {
            OrderDetails = new OrderDetails();
            test1 = new Dictionary<string, int> { { "A", 3 }, { "B", 5 }, { "C", 1 }, { "D", 1 } };
            test2 = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 }};
            test3 = new Dictionary<string, int> { { "A", 5 }, { "B", 5 }, { "C", 1 }};
        }

        [Test]
        [TestCase(280)]
        public void TestCalculateCost(int output)
        {
            foreach(var item in test1)
            {
                OrderDetails.AddOrders(item.Key, item.Value);
            }

            var promotionEngine = new PromotionEngine();
            var cost = promotionEngine.CalculateCost(OrderDetails);

            Assert.AreEqual(cost, output);
        }

        [Test]
        [TestCase(100)]
        public void TestCalculateCost2(int output)
        {
            foreach (var item in test2)
            {
                OrderDetails.AddOrders(item.Key, item.Value);
            }

            var promotionEngine = new PromotionEngine();
            var cost = promotionEngine.CalculateCost(OrderDetails);

            Assert.AreEqual(cost, output);
        }

        [Test]
        [TestCase(370)]
        public void TestCalculateCost3(int output)
        {
            foreach (var item in test3)
            {
                OrderDetails.AddOrders(item.Key, item.Value);
            }

            var promotionEngine = new PromotionEngine();
            var cost = promotionEngine.CalculateCost(OrderDetails);

            Assert.AreEqual(cost, output);
        }
    }
}
