using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using WatiN.Core;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SpecFlowDemoApp.Web.AcceptanceTests.Steps
{
    [Binding]
    class LoginSteps
    {
        private IWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver();

        [Given("I am at the '(.*)' page")]
        public void GivenIAmAtTheLoginPage(string pageName)
        {
            driver.Navigate().GoToUrl(Context.PageNameUrlMap[pageName]);
        }

        [When("I fill in the following form")]
        public void WhenIFillInTheFollowingForm(TechTalk.SpecFlow.Table table)
        {
            foreach (var row in table.Rows)
            {
                var textField = driver.FindElement(By.Name(row["field"]));

                if (!textField.Displayed)
                    Assert.Fail("Expected to find a text field with the name of '{0}'.", row["field"]);

                textField.SendKeys(row["value"]);
            }
        }

        [When("I click the '(.*)' button")]
        public void AndIClickTheLoginButton(string buttonName)
        {
            var loginButton = driver.FindElement(By.Name(buttonName));

            if (!loginButton.Displayed)
                Assert.Fail("Expected to find a button with the value of 'Login'.");

            loginButton.Click();
        }

        [Then("I should be at the '(.*)' page")]
        public void ThenIShouldBeAtTheHomePage(string pageName)
        {
            var expectedURL = Context.PageNameUrlMap[pageName];
            var actualURL = driver.Url;
            driver.Close();
            Assert.AreEqual(expectedURL, actualURL);
        }
    }
}
