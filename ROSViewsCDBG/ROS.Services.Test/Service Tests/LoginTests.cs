﻿using ROS.Services.Helpers;
using ROS.Services.Services;
using Xunit;

namespace ROS.Services.Test.Service_Tests
{
    
    public class LoginUnitTests
    {
        [Fact]
        public void InvalidCredentialsShouldReturnFalse()
        {
            var email = "test123";
            var password = "test123";
            var service = ServiceLocator.Instance.LoginService;
         

            var result = service.ConfirmUserCredentials(email, password);
            
            Assert.False(result);
        }
        [Fact]
        public void ValidCredentialsShouldReturnTrue()
        {
            var email = "sven@svensson.com";
            var password = "Password123";
            var service = ServiceLocator.Instance.LoginService;

            var result = service.ConfirmUserCredentials(email, password);

            Assert.True(result);
        }
    }
}
