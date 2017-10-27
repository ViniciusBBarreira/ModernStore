using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests.Tests
{
    [TestClass]
    public class CustomersTests
    {
        private readonly User _user = new User("FirstName", "Password", "Password");
        private readonly Name _name = new Name("FirstName", "LastName");
        private readonly Document _document = new Document("90653661134");
        private readonly Email _email = new Email("customer@email.com");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var name = new Name("", "LastName");
            var customer = new Customer(name, _email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var name = new Name("FirstName", "");
            var customer = new Customer(name, _email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailNameShouldReturnANotification()
        {
            var email = new Email("customer");
            var customer = new Customer(_name, email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
