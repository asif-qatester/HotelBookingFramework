using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingFramework;
using HotelBookingFramework.Pages;

namespace HotelBookingTests
{
    [TestClass]
    public class LoginTests:HotelBookingTest
    {
        [TestMethod]
        public void User_Can_Login()
        {
            Assert.IsTrue(BookingPage.IsAt, "Failed to Login");
        }
    }
}
