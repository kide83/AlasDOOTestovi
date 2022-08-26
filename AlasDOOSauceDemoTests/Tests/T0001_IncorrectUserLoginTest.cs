using AlasDOOSauceDemoTests.POMs;
using System.Threading;
using Xunit;

namespace AlasDOOSauceDemoTests.Tests
{
    public class T0001_IncorrectUserLoginTest : BaseTest
    {
        private readonly LoginPage logInPage;

        public T0001_IncorrectUserLoginTest()
        {
            logInPage = new LoginPage(Driver);
        }

        [Theory(DisplayName = "Test: User Login With Incorrect 'UN / PW' Combinations")]
        [InlineData("standard_user", "")] // UN Correct, PW Empty
        [InlineData("", "secret_sauce")] // UN Empty, PW Correct
        [InlineData("someemail5312@gmail.com", "secret_sauce")] // UN Incorrect, PW Correct
        [InlineData("standard_user", "BadPass2213")] // UN Correct, PW Incorrect
        public void LoginWithIncorrectCredentialsCheck(string userName, string password)
        {
            //Arrange
            Navigate();

            var username_input = userName;
            var password_input = password;

            //Act
            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);

            //Assert
            // If we see login button, then we are still at login page and are not logged in
            Assert.True(logInPage.DisplayedLoginButton());
        }

    }
}
