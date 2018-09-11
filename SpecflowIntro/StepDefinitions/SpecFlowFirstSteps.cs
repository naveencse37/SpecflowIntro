using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowIntro.DataClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowIntro
{
    [Binding]
    public class SpecFlowFirstSteps
    {
        //public readonly Credentials credentials;
        //public SpecFlowFirstSteps(Credentials credentials) // use it as ctor parameter
        //{
        //    this.credentials = credentials;
        //}
        IWebDriver driver = new ChromeDriver();
        private object credentials;

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
            var data = table.CreateDynamicSet();

            foreach (var item in data)
            {
                driver.FindElement(By.Id("user_email")).SendKeys(item.username);
                driver.FindElement(By.Id("user_password")).SendKeys(item.password);
                    //credentials.UserName = item.username;
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
            //ScenarioContext.Current["uname"] = "naveencse37@gmail.com";
            //var uname = ScenarioContext.Current["uname"];
            //username = ScenarioContext.Current.Get<IEnumerable<Credentials>>("Username");
            // var credentials = ScenarioContext.Current.Get<IEnumerable<Credentials>>();
            //table.CompareToSet<Credentials>(credentials);
            //foreach (var emp in credentials)
            //{
            //var credentials = ScenarioContext.Current.Get<Credentials>();
            var uname = ScenarioContext.Current.Get<IEnumerable<Credentials>>();
            // foreach (var uname in credentials)
            //{
                driver.FindElement(By.XPath("//*[@id='my_account']/span")).Click();
                driver.FindElement(By.XPath("//*[@id='wrap']/header/div/div[2]/nav/ul[2]/li[1]/ul/li[1]/a")).Click();
                var actual = driver.FindElement(By.Id("user_email")).GetAttribute("value");
                //Assert.AreEqual(actual, uname.UserName);
              //  Console.WriteLine(uname.UserName);
            driver.Quit();
           // }
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
