using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests.Tests
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer(new Name("FirstName", "LastName"), new Email("customer@email.com"), new Document("90653661134"), new User("FirstName", "Password", "Password"));

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {

            var product = new Product("ProductTitle", 1, 0, "ProductTitle.jpg");
            var order = new Order(_customer, 1, 0);

            order.AddItem(new OrderItem(product, 1));

            Assert.AreEqual(1, order.Notifications.Count);
            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        {
            var product = new Product("ProductTitle", 1, 10, "ProductTitle.jpg");

            var order = new Order(_customer, 1, 0);
            order.AddItem(new OrderItem(product, 5));

            Assert.IsTrue(product.QuantityOnHand == 5);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderTheTotalShoulBe510()
        {
            var product = new Product("ProductTitle", 100, 10, "ProductTitle.jpg");

            var order = new Order(_customer, 15, 5);
            order.AddItem(new OrderItem(product, 5));

            Assert.IsTrue(order.Total() == 510);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderTheSubTotalShoulBe1200()
        {
            var product = new Product("ProductTitle", 150, 10, "ProductTitle.jpg");

            var order = new Order(_customer, 60, 30);
            order.AddItem(new OrderItem(product, 8));

            Assert.IsTrue(order.SubTotal() == 1200);
        }
    }
}
