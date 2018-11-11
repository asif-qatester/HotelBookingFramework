using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingFramework.Pages;
using HotelBookingFramework.Workflows;

namespace HotelBookingTests.SmokeTests
{
    [TestClass]
    public class DeleteBookingTests:HotelBookingTest
    {
        [TestMethod]
        public void Can_Delete_a_Booking()
        {
            //Go to Bookings Page
            BookingPage.GoTo();
            //delete the first booking from the list
            BookingPage.DeleteFirstBooking()                
                       .Delete();                       
            //verify that the booking id is successfully deleted            
            Assert.AreSame(BookingPage.ConfirmDeletionMessage(), "Not Found", "delete was unsuccessful");
            
        }
    }
}
