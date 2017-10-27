using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests.Tests
{
    [TestClass]
    public class UsersTests
    {
        [TestMethod]
        [TestCategory("User - New User")]
        public void GivenAnInvalidUserNameShouldReturnANotification()
        {
            var user = new User("", "Password", "Password");
            Assert.IsFalse(user.IsValid());
        }

        [TestMethod]
        [TestCategory("User - New User")]
        public void GivenAnInvalidPasswordShouldReturnANotification()
        {
            var user = new User("UserName", "", "");
            Assert.IsFalse(user.IsValid());
        }
    }
}
