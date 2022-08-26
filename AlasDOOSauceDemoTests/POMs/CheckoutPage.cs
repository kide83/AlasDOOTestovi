using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlasDOOSauceDemoTests.POMs
{
    public class CheckoutPage
    {
        private IWebDriver driver { get; }

        public CheckoutPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement FirstNameField => driver.FindElement(By.Id("first-name"));
        public IWebElement LastNameField => driver.FindElement(By.Id("last-name"));
        public IWebElement ZIPCodeField => driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
        public IWebElement FinishButton => driver.FindElement(By.Id("finish"));
        public IWebElement CheckoutComplete => driver.FindElement(By.Id("checkout_complete_container"));

        public bool DisplayedFirstNameField() => FirstNameField.Displayed;
        public bool DisplayedLastNameField() => LastNameField.Displayed;
        public bool DisplayedZIPCodeField() => ZIPCodeField.Displayed;
        public bool DisplayedContinueButton() => ContinueButton.Displayed;
        public bool DisplayedFinishButton() => FinishButton.Displayed;
        public bool DisplayedCheckoutCoplete() => CheckoutComplete.Displayed;

        public void FillCheckoutForm(string firstName_input, string lastName_input, string zipCode_input)
        {
            FirstNameField.SendKeys(firstName_input);
            LastNameField.SendKeys(lastName_input);
            ZIPCodeField.SendKeys(zipCode_input);
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public void ClickFinishButton()
        {
            FinishButton.Click();
        }

    }
}
