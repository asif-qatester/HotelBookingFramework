using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingFramework.Pages;
using HotelBookingFramework.Workflows;

namespace HotelBookingTests.SmokeTests
{
    [TestClass]
    public class CreateBookingTests:HotelBookingTest
    {
        [TestMethod]
        public void Can_Create_a_Booking()
        {
            //Go to Bookings Page,get the bookings count and store
            BookingPage.GoTo();
            BookingPage.StoreCount();
            //create a new booking and save
            BookingPage.CreateBooking("TestFN","TestSN")
                       .WithDetails("152.23","true","2018-11-07","2018-11-09")
                       .Save();
            //Go to Bookings Page,get the new bookings count (should be greater)
            BookingPage.GoTo();
            Assert.AreEqual(BookingPage.PreviousBookingsCount + 1, BookingPage.CurrentBookingsCount, "Count of bookings did not increase");
        }

        [TestMethod]
        public void Can_Create_a_Booking_Using_BookingCreator()
        {
            //Go to Bookings Page,get the bookings count and store
            BookingPage.GoTo();
            BookingPage.StoreCount();
            //create a new booking and save
            BookingCreator.CreateBooking();
            //Go to Bookings Page,get the new bookings count (should be greater)
            BookingPage.GoTo();
            Assert.AreEqual(BookingPage.PreviousBookingsCount + 1, BookingPage.CurrentBookingsCount, "Count of bookings did not increase");
        }
    }
}
