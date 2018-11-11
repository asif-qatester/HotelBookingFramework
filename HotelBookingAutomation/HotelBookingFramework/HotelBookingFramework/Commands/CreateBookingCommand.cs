using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace HotelBookingFramework.Commands
{
        public class CreateBookingCommand
        {
            private string firstName;
            private string surName;
            private string price;
            private string deposit;
            private string checkIn;
            private string checkOut;
            public CreateBookingCommand(string firstName, string surName)
            {
                this.firstName = firstName;
                this.surName = surName;
            }
            public CreateBookingCommand(string price, string deposit, string checkIn, string checkOut)
            {
                // TODO: Complete member initialization

                this.price = price;
                this.deposit = deposit;
                this.checkIn = checkIn;
                this.checkOut = checkOut;
            }
            public CreateBookingCommand WithDetails(string price,string deposit,string checkIn, string checkOut)
            {
                decimal d = Decimal.Parse(price);
                decimal rounded = Decimal.Round(d, 2);
                this.price = rounded.ToString();
                this.deposit = deposit;
                this.checkIn = checkIn;
                this.checkOut = checkOut;
                return this;
            }
            public void Save()
            {
                var firstNameInput = Driver.Instance.FindElement(By.Id("firstname"));
                firstNameInput.SendKeys(firstName);
                var surNameInput = Driver.Instance.FindElement(By.Id("lastname"));
                surNameInput.SendKeys(surName);
                var priceInput = Driver.Instance.FindElement(By.Id("totalprice"));
                priceInput.SendKeys(price);
                SelectElement deposit = new SelectElement(Driver.Instance.FindElement(By.Id("depositpaid")));
                deposit.SelectByText("true");
                var checkInInput = Driver.Instance.FindElement(By.Id("checkin"));
                checkInInput.SendKeys(checkIn);
                var checkOutInput = Driver.Instance.FindElement(By.Id("checkout"));
                checkOutInput.SendKeys(checkOut);


                var saveButton = Driver.Instance.FindElement(By.XPath("//*[@id='form']/div/div[7]/input"));
                saveButton.Click();
            }
        }
}

