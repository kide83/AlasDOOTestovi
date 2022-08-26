using OpenQA.Selenium;

namespace AlasDOOSauceDemoTests.POMs
{
    public class LoginPage
    {
        private IWebDriver driver { get; }

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement Username => driver.FindElement(By.Id("user-name"));

        public IWebElement Password => driver.FindElement(By.Id("password"));

        public IWebElement LogInButton => driver.FindElement(By.Id("login-button"));

        public bool DisplayedUsername() => Username.Displayed;

        public bool DisplayedPassword() => Password.Displayed;

        public bool DisplayedLoginButton() => LogInButton.Displayed;

        public void LogIn(string username_input, string password_input)
        {
            Username.SendKeys(username_input);
            Password.SendKeys(password_input);
            LogInButton.Click();
        }

    }
}
