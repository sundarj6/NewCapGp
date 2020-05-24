using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using NUnit.Framework;


namespace NewCG05232020.Steps
{
    [Binding]
    public class LoginNegativTestSteps
    {
        //IWebDriver driver = new FirefoxDriver();
        IWebDriver driver = new ChromeDriver();
        [Given(@"User at the CG US Ind Inv Site")]
        public void GivenUserAtTheCGUSIndInvSite()
        {
            driver.Navigate().GoToUrl("https://www.capitalgroup.com/individual/");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Then(@"User Launches Login Page")]
        public void ThenUserLaunchesLoginPage()
        {
            IWebElement element_login_link = driver.FindElement(By.LinkText("Login"));
            element_login_link.Click();
            //Thread.Sleep(5);
            string TitleCountryPage3 = driver.Title;
            Console.WriteLine("Title is:" + TitleCountryPage3);
            Assert.IsTrue(TitleCountryPage3.Contains("Log In | American Funds"));
        }
        //[When(@"User enter Invalid UserName and/Or Invalid Password")]
        [When(@"User enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string username, string password)
        {
            Thread.Sleep(50);
            IWebElement element_loginid = driver.FindElement(By.Id("loginId"));
            element_loginid.Clear();
            element_loginid.SendKeys(username);
            IWebElement element_password = driver.FindElement(By.Id("password"));
            element_password.Clear();
            element_password.SendKeys(password);

            //User Click on Submit Button
            IWebElement element_submit = driver.FindElement(By.XPath("//button[@type='submit']"));
            element_submit.Click();
        }


        [Then(@"Invalid user name password unsucessful login messge display")]
        public void ThenInvalidUserNamePasswordUnsucessfulLoginMessgeDisplay()
        {
            var ErrorText = driver.FindElement(By.XPath("//p[contains(@class, 'error bold') and text() = 'You entered invalid login information.']")).Text;
            if (
                ErrorText.Contains("You entered invalid login information."))
            {
                Console.WriteLine("Login Negative Test Passed");
            }
            else
            { Console.WriteLine("Login Negative Test Failed"); }
        }

        [When(@"Login Button should be displayed")]
        public void WhenLoginButtonShouldBeDisplayed()
        {

            bool element_login_link = driver.FindElement(By.LinkText("Login")).Displayed;
            if (element_login_link == true)
            {
                Console.WriteLine("Login Negative Test- Login Button Displayed Passed");
            }
            else
            { Console.WriteLine("Login Negative Test Login Button Displayed Failed"); }
        }

        [Then(@"User Closes browser")]
        public void ThenUserClosesBrowser()
        {
            //Browser_Close
            driver.Close();
            driver.Quit();
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }

        }
    }
}
