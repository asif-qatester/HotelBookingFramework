using System;
using System.Collections.Generic;
#region Directives
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using HotelBookingFramework.Commands;
#endregion

namespace HotelBookingFramework.Pages
{
    public class BookingPage
    {
        #region Helpers
        public static bool IsAt
        {
            get
            {
                //Refactor: we can create a generalized IsAt for all pages
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                    return h1s[0].Text == "Hotel booking form";
                return false;
            }

        }
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
            Thread.Sleep(1000);
        }
        #endregion

        #region CreateBooking
        public static CreateBookingCommand CreateBooking(string firstName, string surName)
        {
            return new CreateBookingCommand(firstName,surName);
        }
        public static CreateBookingCommand WithDetails(string price, string deposit, string checkIn, string checkOut)
        {
            return new CreateBookingCommand(price,deposit,checkIn,checkOut);
        }
        #endregion

        #region CountBookings
        private static int lastCount;
        public static void StoreCount()
        {
            lastCount = GetBookingsCount();
        }
        private static int GetBookingsCount()
        {
            var countbookings = Driver.Instance.FindElements(By.ClassName("row")).Count();
            return countbookings;
        }
        public static int PreviousBookingsCount
        {
            get { return lastCount; }
        }
        public static int CurrentBookingsCount
        {
            get { return GetBookingsCount(); }
        }
        #endregion

        #region DeleteBooking

        public static DeleteBookingCommand DeleteFirstBooking()
        {
            return new DeleteBookingCommand();
        }
        public static DeleteBookingCommand DeleteBookingByBookingId(string bookingId)
        {
            return new DeleteBookingCommand(bookingId);
        }
        public static string ConfirmDeletionMessage()
        {
            return new DeleteBookingCommand().ConfirmDelete();
        }
        #endregion        
    }
}
