using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace HotelBookingFramework.Commands
{
    public class DeleteBookingCommand
    {
        private string bookingId;
        private string deletedBookingId;
        public DeleteBookingCommand()
        {
        }
        public DeleteBookingCommand(string bookingId)
        {
            this.bookingId = bookingId;
        }
        public void Delete()
        {
            //get all the rows which are having booking ids and store 
            var bookingIdCollection = Driver.Instance.FindElements(By.XPath("//div[(@id) and (@class='row')]"));
            //check if there are more than 0 rows
            if(bookingIdCollection.Count>0)
            {
                //if yes,get the booking id of the first record
                var bookingId = bookingIdCollection[0].GetAttribute("id");
                deletedBookingId = bookingId;             
                // delete the first record
                var deleteButton = Driver.Instance.FindElement(By.XPath(string.Format("//*[@id=" + "'" + bookingId + "'" + "]/div[7]/input")));
                deleteButton.Click();
              
            }
            else
            {
                //if count is 0 then do nothing because there are no records to delete

            }
        }

        public string ConfirmDelete()
        {
            //if there is a booking id then verify 
            if (deletedBookingId != null)
            {
                Driver.Instance.Navigate().GoToUrl(string.Format("http://hotel-test.equalexperts.io/booking" + deletedBookingId));
                string Message = Driver.Instance.FindElement(By.TagName("pre")).Text;
                return Message;
            }
            //if there is no booking id means no records to delete 
            else
            {
                return "Not Found";
            }
        }
    }
}
