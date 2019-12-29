using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;


namespace ZavrsniTest
{
    class SeleniumBaseClass
    {
        IWebDriver driver;
        private uint _wait = 0;
        private IWebElement _element = null;

        public IWebDriver Driver
        {
            get { return this.driver; }
            set { this.driver = value; }
        }
        public uint Wait
        {
            get { return this._wait; }
            set { this._wait = value * 1000; }
        }
        public void SendKeys(string keysToSend, bool sendEnter = true, IWebElement element = null)
        {
            IWebElement el = null;
            if (element == null)
            {
                if (this._element == null)
                {
                    throw new Exception("No element defined, cant send keys");
                }
                else
                {
                    el = this._element;
                }
            }
            else
            {
                el = element;
            }
            el.SendKeys(keysToSend);
            if (this._wait > 0)
            {
                this.DoWait();
                if (sendEnter)

                    el.SendKeys(Keys.Enter);
            }

        }
        public IWebElement FindElement(By selector)
        {
            IWebElement element = null;
            try
            {
                element = this.driver.FindElement(selector);
                this._element = element;
            }
            catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw e;
            }

            return element;
        }
        public void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
            if (this._wait > 0)
            {
                this.DoWait();
            }
        }

        public void DoWait(uint timeToWait = 0)
        {
            uint Waitfor = 0;
            if (timeToWait > 0)
            {
                Waitfor = timeToWait * 1000;

            }
            else
            {
                Waitfor = this._wait;
            }
            System.Threading.Thread.Sleep(Convert.ToInt32(Waitfor));
        }
        public ReadOnlyCollection<IWebElement> FindElements(By selector)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = this.driver.FindElements(selector);
            }
            catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw e;
            }
            return elements;
        }
        public void Close()
        {
            this.driver.Close();
        }

    }
}