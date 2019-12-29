using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ZavrsniTest
{
    class Testovi:SeleniumBaseClass

    {

        [Test]
        public void Test1()
        {
            this.Navigate("http://test5.qa.rs/");
            DoWait(2);
            this.FindElement(By.LinkText("Register"))?.Click();
            DoWait(2);
            this.FindElement(By.Name("ime"))?.SendKeys("Filip");
            this.FindElement(By.Name("prezime"))?.SendKeys("Vucinic");
            this.FindElement(By.Name("email"))?.SendKeys("fvucinic@maher.com");
            this.FindElement(By.Name("korisnicko"))?.SendKeys("fvucinic");
            this.FindElement(By.Id("password"))?.SendKeys("maher123");
            this.FindElement(By.Id("passwordAgain"))?.SendKeys("maher123");
            DoWait(2);
            this.FindElement(By.Name("register"))?.Click();
            DoWait(2);
            IWebElement uspeh = this.FindElement(By.XPath("//div[@class='alert alert-success']"));
            if (uspeh != null)
            {
                Assert.Pass("Korisnik je uspesno registrovan i test je prosao");
            }
            else
            {
                Assert.Fail("Korisnik nije mogao da bude registrovan i test nije prosao");
            }
        }
        [Test]
        public void Test2()
        {
            this.Navigate("http://test5.qa.rs/");
            DoWait(2);
            this.FindElement(By.LinkText("Login"))?.Click();
            DoWait(2);
            
            this.FindElement(By.XPath("//input[@name='username']"))?.SendKeys("fvucinic");
            this.FindElement(By.XPath("//input[@name='password']"))?.SendKeys("maher123");
            DoWait(2);
            this.FindElement(By.XPath("//input[@name='login']"))?.Click();
            DoWait(2);
            IWebElement welcome = this.FindElement(By.XPath("//div[@class='col-sm-12 text-center']/h2"));
            string w = welcome.Text;
            Assert.AreEqual("Welcome back, Filip", w);


            //IWebElement small = this.FindElement(By.XPath("(//select[@name='quantity'])[2]"));
            //var selection = new SelectElement(small);
            //selection.SelectByValue("6");
            //DoWait(1);
            //this.FindElement(By.XPath("(//input[@type='submit' and @value='ORDER NOW'])[2]"))?.Click();
            //IWebElement total1 = this.FindElement(By.XPath("//div[@class='panel-footer'])[2]"));
            //DoWait(2);


            //IWebElement total2 = this.FindElement(By.XPath("//tbody//tr[1]/td[4]"));
            //DoWait(2);
            //string t1 = total1.Text.Substring(1);

            //string t2 = total2.Text.Substring(1);

            //int m1 = Convert.ToInt32(t1);

            //int m2 = Convert.ToInt32(t2);

            //Assert.AreEqual(6 * m1, m2);
        }
        [Test]
        public void Test3()
        {
            this.Navigate("http://test5.qa.rs/");
            DoWait(2);
            this.FindElement(By.LinkText("Login"))?.Click();
            DoWait(2);

            this.FindElement(By.XPath("//input[@name='username']"))?.SendKeys("fvucinic");
            this.FindElement(By.XPath("//input[@name='password']"))?.SendKeys("maher123");
            DoWait(2);
            this.FindElement(By.XPath("//input[@name='login']"))?.Click();
            this.Navigate("http://test5.qa.rs/");
            DoWait(2);
            IWebElement small = this.FindElement(By.XPath("(//select[@name='quantity'])[2]"));
            var selection1 = new SelectElement(small);
            selection1.SelectByValue("5");
            DoWait(1);
            this.FindElement(By.XPath("(//input[@type='submit' and @value='ORDER NOW'])[2]"))?.Click();
            DoWait(2);
            this.FindElement(By.LinkText("Continue shopping"))?.Click();
            DoWait(2);
            IWebElement pro = this.FindElement(By.XPath("(//select[@name='quantity'])[3]"));
            var selection2 = new SelectElement(pro);
            selection2.SelectByValue("9");
            DoWait(1);
            this.FindElement(By.XPath("(//input[@type='submit' and @value='ORDER NOW'])[3]"))?.Click();
            IWebElement total1 = this.FindElement(By.XPath("//tbody/tr[4]"));
            string t1 = total1.Text.Substring(8);
            int m1 = Convert.ToInt32(t1);
            DoWait(1);
            this.FindElement(By.XPath("//input[@name='checkout']"))?.Click();
            DoWait(2);
            //IWebElement total2 = this.FindElement(By.XPath("//div[@class='col-sm-12 font-size-18 text-center']/h3"));
            //string t2 = total2.Text.Substring(54);
            //int m2 = Convert.ToInt32(total2);
            Assert.AreEqual(14800, m1);


        }


        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new ChromeDriver();
        }
        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
