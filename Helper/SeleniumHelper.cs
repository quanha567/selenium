
using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PhoneNumber.Models;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace PhoneNumber.Helper
{
    class SeleniumHelper
    {
        private readonly string ZALO_URL = "https://chat.zalo.me/";
        private readonly string INPUT_SEARCH_ID = "contact-search-input";
        private readonly string INPUT_MESSAGE = "input_line_0";
        private readonly string MESSAGE = "HELLO! THIS IS A MESSAGE FROM BOT TEST";
        private readonly string CHECK_ITEM_CLASS = "conv-item-title__name";
        private readonly string QRCODE_CLASS = "qrcode";
        private readonly string DROP_FILE = "//div[@data-translate-inner='STR_DROP_FILE_HERE']";
        private readonly string VN_PHONENUMBER_PATTERN = @"(((\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\b";
        private readonly string VALID = "ĐÃ SỬ DỤNG";
        private readonly string INVALID = "CHƯA SỬ DỤNG";
        private readonly string WRONG = "SỐ ĐIỆN THOẠI KHÔNG ĐÚNG";
        private readonly int MAX_LIMIT = 30; // maximum phone number for per check
        private string profile = @"C:\Users\LENOVO\AppData\Local\Google\Chrome\User Data";

        public SeleniumHelper() { }
        public SeleniumHelper(string profile)
        {
            this.profile = profile;
        }

        private ChromeDriver CreateSelenium()
        {
            var option = new ChromeOptions();
            option.AddArgument($"--user-data-dir={profile}");
            option.AddArgument("--no-sandbox");
            var driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl(ZALO_URL);

            return driver;
        }

        public static void DropFile(WebDriver driver, string filePath, IWebElement target, int offsetX, int offsetY)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            String JS_DROP_FILE =
                "var target = arguments[0]," +
                "    offsetX = arguments[1]," +
                "    offsetY = arguments[2]," +
                "    document = target.ownerDocument || document," +
                "    window = document.defaultView || window;" +
                "" +
                "var input = document.createElement('INPUT');" +
                "input.type = 'file';" +
                "input.style.display = 'none';" +
                "input.onchange = function () {" +
                "  var rect = target.getBoundingClientRect()," +
                "      x = rect.left + (offsetX || (rect.width >> 1))," +
                "      y = rect.top + (offsetY || (rect.height >> 1))," +
                "      dataTransfer = { files: this.files };" +
                "" +
                "  ['dragenter', 'dragover', 'drop'].forEach(function (name) {" +
                "    var evt = document.createEvent('MouseEvent');" +
                "    evt.initMouseEvent(name, !0, !0, window, 0, 0, 0, x, y, !1, !1, !1, !1, 0, null);" +
                "    evt.dataTransfer = dataTransfer;" +
                "    target.dispatchEvent(evt);" +
                "  });" +
                "" +
                "  setTimeout(function () { document.body.removeChild(input); }, 25);" +
                "};" +
                "document.body.appendChild(input);" +
                "return input;";

            IWebElement input = (IWebElement)driver.ExecuteScript(JS_DROP_FILE, target, offsetX, offsetY);
            input.SendKeys(filePath);
            wait.Until(ExpectedConditions.StalenessOf(input));
        }

        public bool CheckFormat(string phoneNumber)
        {
            var regex = new Regex(VN_PHONENUMBER_PATTERN);

            return regex.IsMatch(phoneNumber);
        }

        public Phone CheckPhoneNumber(string phoneNumber)
        {
            if(!CheckFormat(phoneNumber))
            {
                return new Phone(1, phoneNumber, "", WRONG);
            }

            var driver = CreateSelenium();
            Thread.Sleep(1000);
            try
            {
                // check login if is not wait for 10 seconds
                if(driver.FindElement(By.ClassName(QRCODE_CLASS)) != null) 
                    Thread.Sleep(20000);
            } catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
            var fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.Until(dom => dom.FindElement(By.Id(INPUT_SEARCH_ID))).SendKeys(phoneNumber);
            //var inputElement = driver.FindElement(By.Id(INPUT_SEARCH_ID));
            //inputElement.SendKeys(phoneNumber);
            var phone = new Phone();
            Thread.Sleep(500);
            try
            {
                var findElement = driver.FindElement(By.ClassName(CHECK_ITEM_CLASS));
                if (findElement != null)
                {
                    phone.state = VALID;
                    phone.name = findElement.Text;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                phone.state = INVALID;
            }
            driver.Quit();

            return phone;
        }

        public void CheckPhoneNumbers(List<Phone> phoneNumberList, int startIndex, ProgressBar pgb)
        {
            int count = 1;
            var driver = CreateSelenium();
            var fluentWait = new DefaultWait<IWebDriver>(driver);
            pgb.Value = 0;

            Thread.Sleep(1000);
            try
            {
                // check login if is not wait for 10 seconds
                if (driver.FindElement(By.ClassName(QRCODE_CLASS)) != null) 
                    Thread.Sleep(TimeSpan.FromSeconds(15));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            var searchInput = fluentWait.Until(dom => dom.FindElement(By.Id(INPUT_SEARCH_ID)));
            //var searchInput = driver.FindElement(By.Id(INPUT_SEARCH_ID));

            // loop over phone number list and call again this function when loop index = max_limit
            for (int i = startIndex * MAX_LIMIT; i < phoneNumberList.Count && count <= MAX_LIMIT; i++, count++)
            {
                var item = phoneNumberList[i];

                if (!CheckFormat(item.phoneNumber))
                {
                    item.state = WRONG;
                }
                else
                {
                    searchInput.SendKeys(item.phoneNumber);
                    Thread.Sleep(200); // total time => 0.2s * 50 = 10s;
                    try
                    {
                        var findElement = driver.FindElement(By.ClassName(CHECK_ITEM_CLASS));

                        item.state = VALID;
                        item.name = findElement.Text;
                        findElement.Click();
                        var inputMessage = driver.FindElement(By.Id(INPUT_MESSAGE));
                        Thread.Sleep(200);
                        inputMessage.SendKeys(MESSAGE);
                        inputMessage.SendKeys(Keys.Enter);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                        item.state = INVALID;
                    }
                    //Thread.Sleep(250);
                    searchInput.Clear();
                }

                //progress
                pgb.Value += 2;
            }
            driver.Quit();
            /*if (count < 50) return;
            Thread.Sleep(TimeSpan.FromMinutes(1));
            CheckPhoneNumbers(phoneNumberList, startIndex + 1, pgb);*/
        }

        public void SendMessageAndPicture(string phoneNumber, string picDir, string message)
        {
            if (!CheckFormat(phoneNumber))
            {
                return;
            }

            var driver = CreateSelenium();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            
            Thread.Sleep(3000);
            try
            {
                // check login if is not wait for 10 seconds
                if (driver.FindElement(By.ClassName(QRCODE_CLASS)) != null)
                    Thread.Sleep(TimeSpan.FromSeconds(15));
            }
            catch (NoSuchElementException err)
            {
                Console.WriteLine(err.Message);
            }
            wait.Until(ExpectedConditions.ElementExists(By.Id(INPUT_SEARCH_ID))).SendKeys(phoneNumber);
            try
            {
                wait.Timeout = TimeSpan.FromSeconds(3);
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(CHECK_ITEM_CLASS))).Click();
                //var dropArea = wait.Until(ExpectedConditions.ElementExists(By.Id(DROP_FILE_REVIEW)));
                var input = wait.Until(ExpectedConditions.ElementExists(By.Id(INPUT_MESSAGE)));
                //DropFile(driver, picDir, dropArea, 0, 0);
                input.SendKeys(message);
                input.SendKeys(Keys.Control + "v");
                Thread.Sleep(500);
                //input.SendKeys(Keys.Enter);
                new Actions(driver).SendKeys(Keys.Enter).Perform();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Errol");
            }
            finally
            {
                driver.Quit();
            }
        }

        public void SendFile(string phoneNumber, string picDir)
        {
            if (!CheckFormat(phoneNumber))
            {
                return;
            }

            var driver = CreateSelenium();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);

            Thread.Sleep(3000);
            try
            {
                // check login if is not wait for 10 seconds
                if (driver.FindElement(By.ClassName(QRCODE_CLASS)) != null)
                    Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            wait.Until(ExpectedConditions.ElementExists(By.Id(INPUT_SEARCH_ID))).SendKeys(phoneNumber);
            try
            {
                wait.Timeout = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(CHECK_ITEM_CLASS))).Click();
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(BTN_SEND_PHOTO))).Click();
                Thread.Sleep(500);
                var dropArea = wait.Until(ExpectedConditions.ElementExists(By.XPath(DROP_FILE)));
                DropFile(driver, picDir, dropArea, 0, 0);
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show(err.Message);
            }
            driver.Quit();
        }

        /*public void SendFile(string phoneNumber, string fileDir)
        {
            if (!CheckFormat(phoneNumber))
            {
                return;
            }

            var driver = CreateSelenium();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);

            Thread.Sleep(3000);
            try
            {
                // check login if is not wait for 10 seconds
                if (driver.FindElement(By.ClassName(QRCODE_CLASS)) != null)
                    Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            wait.Until(ExpectedConditions.ElementExists(By.Id(INPUT_SEARCH_ID))).SendKeys(phoneNumber);
            try
            {
                wait.Timeout = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(CHECK_ITEM_CLASS))).Click();
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(BTN_SEND))).Click();
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(BTN_SEND_FILE))).Click();
                Thread.Sleep(500);
                var dropArea = wait.Until(ExpectedConditions.ElementExists(By.XPath(DROP_FILE)));
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show(err.Message);
            }
            driver.Quit();
        }
        */
    }
}