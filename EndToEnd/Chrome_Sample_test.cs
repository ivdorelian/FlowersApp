using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EndToEnd
{
    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;
        public string homeURL;

        [Test(Description = "Check SauceLabs Homepage for Login Link")]
        public void Login_is_on_home_page()
        {
            homeURL = "https://www.SauceLabs.com";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.FindElement(By.XPath("//a[@href='https://accounts.saucelabs.com/']")));
            IWebElement element = driver.FindElement(By.XPath("//a[@href='https://accounts.saucelabs.com/']"));
            Assert.AreEqual("Sign in", element.GetAttribute("text"));
            element.Click();
            Thread.Sleep(5000);
            // more checks here
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        public void SetupTest()
        {
            homeURL = "http://SauceLabs.com";
            driver = new ChromeDriver();
        }
    }
}