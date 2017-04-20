using System;
using Xunit;
using Moq;
using ROS.Services.Services;
using ROSPersistence.ROSDB;

namespace ROS.Services.Test
{
    
    public class LoginUnitTests
    {
        [Fact]
        public void TestMethod1()
        {
            var email = "test123";
            var password = "test123";
            var service = new LoginService();

            var result = service.ConfirmUserCredentials(email, password);
            
            Assert.False(result);
        }
    }
}
