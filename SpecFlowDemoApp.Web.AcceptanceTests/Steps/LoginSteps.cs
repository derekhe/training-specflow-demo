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
        IWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver();

        [Given("I am at the 'Login' page")]
        public void GivenIAmAtTheLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:9876/authentication/login");
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

        [When("I click the 'Login' button")]
        public void AndIClickTheLoginButton()
        {
            var loginButton = driver.FindElement(By.Name("Login"));

            if (!loginButton.Displayed)
                Assert.Fail("Expected to find a button with the value of 'Login'.");

            loginButton.Click();
        }

        [Then("I should be at the 'Home' page")]
        public void ThenIShouldBeAtTheHomePage()
        {
            var expectedURL = "http://localhost:9876/";
            var actualURL = driver.Url;
            Assert.AreEqual(expectedURL, actualURL);
        }
    }
}
