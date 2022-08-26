using AlasDOOSauceDemoTests.POMs;
using System;
using System.Threading;
using Xunit;

namespace AlasDOOSauceDemoTests.Tests
{
    public class T0005_CheckoutProcessTest : BaseTest
    {
        private readonly LoginPage logInPage;
        private readonly MainPage mainPage;
        private readonly CartPage cartPage;
        private readonly CheckoutPage checkoutPage;

        public T0005_CheckoutProcessTest()
        {
            logInPage = new LoginPage(Driver);
            mainPage = new MainPage(Driver);
            cartPage = new CartPage(Driver);
            checkoutPage = new CheckoutPage(Driver);
        }

        [Fact(DisplayName = "Test: Removing First Item (Backpack) from The Basket")]
        public void GoToCheckoutPageCheck()
        {
            //Arrange
            Navigate();

            var username_input = "standard_user";
            var password_input = "secret_sauce";

            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);

            // Quickly add Backpack and BikeLight to the cart, then navigate to cart page and remove Backpack
            if (mainPage.DisplayedInventoryContainer() == true)
            {
                Navigate("https://www.saucedemo.com/inventory.html");

                mainPage.AddBackpack();

                mainPage.AddBikeLight();

                Thread.Sleep(3000);

                Navigate("https://www.saucedemo.com/cart.html");

                Thread.Sleep(3000);

                cartPage.RemoveBackPack();

                Thread.Sleep(3000);

            }
            else
            {
                Console.WriteLine("Not Logged in.");
            }

            //Act
            // Go to checkout page, fill in personal data in form, click continue button, and on next page click Fiish button
            cartPage.GoToCheckoutPage();

            var firstName_input = "Dejan";
            var lastName_input = "Mirkovic";
            var zipCode_input = "11000";

            checkoutPage.FillCheckoutForm(firstName_input, lastName_input, zipCode_input);

            Thread.Sleep(3000);

            checkoutPage.ClickContinueButton();

            Thread.Sleep(3000);

            checkoutPage.ClickFinishButton();

            Thread.Sleep(3000);

            //Assert
            // Check if "Checkout Complete" message is displayed
            Assert.True(checkoutPage.DisplayedCheckoutCoplete());

        }
 
    }
}
