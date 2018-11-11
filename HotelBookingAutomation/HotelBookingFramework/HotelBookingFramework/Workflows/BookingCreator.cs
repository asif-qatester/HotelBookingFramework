#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingFramework.Pages;
#endregion

namespace HotelBookingFramework.Workflows
{
    public class BookingCreator
    {
        #region CreateBooking
        public static void CreateBooking()
        {
            BookingPage.GoTo();
            FirstName = "TestWFFN";
            SurName = "TestWFSN";
            Price = "235.67";
            Deposit = "true";
            CheckIn = "2018-11-10";
            CheckOut = "2018-11-15";

            BookingPage.CreateBooking(FirstName, SurName)
                       .WithDetails(Price, Deposit, CheckIn, CheckOut)
                       .Save();
        }
        #endregion

        #region Properties
        public static string FirstName
        {
            get;
            set;
        }
        public static string SurName
        {
            get;
            set;
        }
        public static string Price
        {
            get;
            set;
        }
        public static string Deposit
        {
            get;
            set;
        }
        public static string CheckIn
        {
            get;
            set;
        }
        public static string CheckOut
        {
            get;
            set;
        }
        #endregion
    }
}
