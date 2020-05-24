using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace NewCG05232020.Steps
{
    [Binding]
    public class AddTrackerTestSteps
    {

        [Binding]
        public class AddTrackTestSteps
        {
            IWebDriver driver = new ChromeDriver();
            [Given(@"User at US_InvestPage")]
            public void GivenUserAtUS_InvestPage()
            {
                //Launch Browser
                driver.Navigate().GoToUrl("https://www.capitalgroup.com/individual/");
                Thread.Sleep(200);
                driver.Manage().Window.Maximize();
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

            [Given(@"User Navigates to Symbols Page")]
            public void GivenUserNavigatesToSymbolsPage()
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //Mouse Move on Investment Link
                var element_Investment = wait.Until(OpenQA.Selenium.Support.UI.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'INVESTMENTS')]")));
                Actions action = new Actions(driver);
                Thread.Sleep(200);
                action.MoveToElement(element_Investment).Perform();
                Thread.Sleep(2000);
                IWebElement element_symbol = driver.FindElement(By.LinkText("Symbols & Fund Numbers"));
                element_symbol.Click();
                Thread.Sleep(2000);
            }

            [When(@"select the AMCAP Fund and New World Fund")]
            public void WhenSelectTheAMCAPFundAndNewWorldFund()
            {
                //Select the 'AMCAP Fund' and 'New World Fund'
                var element = driver.FindElement(By.XPath("//div[@class='parsys mainParsys']//div//div[3]" +
                    "//table[1]//tbody[1]//tr[12]//td[1]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();
                //IWebElement element_Stock = driver.FindElement(By.XPath("//span[text()='AMCAP']//parent::a[@class='com-mod-sub-header-fund wrap-inline']//parent::div[@class='label-with-icon']//input[@id='0-check-returns']"));
                IWebElement element_Stock = driver.FindElement(By.XPath("//table[@class='responsive']" +
                    "//tr[3]//td[1]//div[1]//label[@Class='allfunds-check-label']"));

                element_Stock.Click();
            }

            [When(@"clicks AddToTracker")]
            public void WhenClicksAddToTracker()
            {
                Thread.Sleep(1000);
                //IWebElement element_Stock2 = driver.FindElement(By.XPath("//div[@class='parsys mainParsys']" +
                //    "//div//div[3]//table[1]//tbody[1]//tr[10]//td[1]//div[1]//label[@class='allfunds-check-label']"));
                IWebElement element_Stock2 = driver.FindElement(By.XPath("//span[contains(text(),'NEWFX')]/parent::a/parent::div/label[contains(@for, '7-check-symbols')]"));

                //span[contains(text(),'NEWFX')]/parent::a/parent::div/label[contains(@for, '7-check-symbols')]
                element_Stock2.Click();
                IWebElement element_Add2Track = driver.FindElement(By.XPath("//div[@class='add-to-watchlist-cell']//div//span[contains(text(),'ADD TO TRACKER')]"));
                element_Add2Track.Click();
                Thread.Sleep(1000);

            }

            [Then(@"Login Page is displayed")]
            public void ThenLoginPageIsDisplayed()
            {
                bool element_login_link = driver.FindElement(By.LinkText("Login")).Displayed;
                if (element_login_link == true)
                {
                    Console.WriteLine("Login Negative Test- Login Button Displayed Passed");
                }
                else
                { Console.WriteLine("Login Negative Test Login Button Displayed Failed"); }
            }

            [Then(@"Close Browser")]
            public void ThenCloseBrowser()
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
}
    
