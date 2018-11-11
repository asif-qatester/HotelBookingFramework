using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingFramework;
using HotelBookingFramework.Pages;

namespace HotelBookingTests
{
    [TestClass]
    public class HotelBookingTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            BookingPage.GoTo();
        }
        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
