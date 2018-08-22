using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowIntro.DataClass;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowIntro
{
    [Binding]
    public class SpecFlowFirstSteps
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I am on ultimate qa login page")]
        public void GivenIAmOnUltimateQaLoginPage()
        {
            driver.Navigate().GoToUrl("https://courses.ultimateqa.com/");
            driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]")).Click();
        }
        
        [Given(@"I have entered username and password")]
        public void GivenIHaveEnteredUsernameAndPassword()
        {
            driver.FindElement(By.Id("user_email")).SendKeys("naveencse37@gmail.com");
            driver.FindElement(By.Id("user_password")).SendKeys("1234abcd");
                
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            driver.FindElement(By.Id("btn-signin")).Click();
            Thread.Sleep(5000);
        }

        [Given(@"I have entered valid credentials")]
        public void GivenIHaveEnteredValidCredentials(Table table)
        {
            var uname = table.CreateDynamicSet();

            foreach (var emp in uname)
            {
                driver.FindElement(By.Id("user_email")).SendKeys(emp.username);
                driver.FindElement(By.Id("user_password")).SendKeys(emp.password);
            }
            // below code works for only one row of data
            // var credentials =  table.CreateInstance<Credentials>();
            //driver.FindElement(By.Id("user_email")).SendKeys(credentials.username);
            //driver.FindElement(By.Id("user_password")).SendKeys(credentials.password);

            //below code works for multiple sets of rows

            //var credentials = table.CreateSet<Credentials>();

            //foreach (var login in credentials)
            // {
            //    driver.FindElement(By.Id("user_email")).SendKeys(login.username);
            //    driver.FindElement(By.Id("user_password")).SendKeys(login.password);
            // }
        }

        [Given(@"I have entered (.*) and (.*)")]
        public void GivenIHaveEnteredNaveencseGmail_ComAndAbcd(string username, string password)
        {
            driver.FindElement(By.Id("user_email")).SendKeys(username);
            driver.FindElement(By.Id("user_password")).SendKeys(password);
        }
        
        [Then(@"I verify the on username on homepage")]
        public void ThenIVerifyTheOnUsernameOnHomepage()
        {
            ScenarioContext.Current["uname"] = "naveencse37@gmail.com";
            var uname = ScenarioContext.Current["uname"];
            driver.FindElement(By.XPath("//*[@id='my_account']/span")).Click();
            driver.FindElement(By.XPath("//*[@id='wrap']/header/div/div[2]/nav/ul[2]/li[1]/ul/li[1]/a")).Click();
            var actual = driver.FindElement(By.Id("user_email")).GetAttribute("value");
            Assert.AreEqual(actual, uname);
        }

        [Then(@"I verify the title on homepage")]
        public void ThenIVerifyTheTitleOnHomepage()
        {
            var title = driver.Title;
            Assert.AreEqual("Ultimate QA", title);
            driver.Quit();

        }
    }
}
