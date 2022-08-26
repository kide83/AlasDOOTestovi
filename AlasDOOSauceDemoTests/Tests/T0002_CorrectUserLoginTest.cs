using AlasDOOSauceDemoTests.POMs;
using System.Threading;
using Xunit;

namespace AlasDOOSauceDemoTests.Tests
{
    public class T0002_CorrectUserLoginTest : BaseTest
    {
        private readonly LoginPage logInPage;
        private readonly MainPage mainPage;

        public T0002_CorrectUserLoginTest()
        {
            logInPage = new LoginPage(Driver);
            mainPage = new MainPage(Driver);
        }

        [Fact(DisplayName = "Test: User Login With Correct Credentials")]
        public void LoginWithCorrectCredentialsCheck()
        {
            //Arrange
            Navigate();

            var username_input = "standard_user";
            var password_input = "secret_sauce";

            //Act
            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);

            //Assert
            // After login, we moved to the main page, which is confirmed via page element with ID "inventory_container"
            Assert.True(mainPage.DisplayedInventoryContainer());
        }

    }
}
