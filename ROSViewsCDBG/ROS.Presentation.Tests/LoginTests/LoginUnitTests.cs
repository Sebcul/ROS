using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROSViewsCDBG.ViewModels;
using Moq;

namespace ROS.Presentation.Tests.LoginTests
{
    [TestClass]
    public class LoginUnitTests
    {
        public void Should_ReturnString_When_EnteringEmail()
        {
            var email = "kalles.kaviar@abba.se";
            var loginViewModel = new LoginWindowViewModel();

            var result = loginViewModel.Email = email;

            Assert.AreEqual(result, email);
        }
    }
}
