using System;
using AlasDOOSauceDemoTests.POMs;
using System.Threading;
using Xunit;

namespace AlasDOOSauceDemoTests.Tests
{
    public class T0004_RemoveFirstItemFromCartTest : BaseTest
    {
        private readonly LoginPage logInPage;
        private readonly MainPage mainPage;
        private readonly CartPage cartPage;

        public T0004_RemoveFirstItemFromCartTest()
        {
            logInPage = new LoginPage(Driver);
            mainPage = new MainPage(Driver);
            cartPage = new CartPage(Driver);
        }

        [Fact(DisplayName = "Test: Removing First Item (Backpack) from The Cart")]
        public void RemovingFirstItemFromBasketCheck()
        {
            //Arrange
            Navigate();

            var username_input = "standard_user";
            var password_input = "secret_sauce";

            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);
            
            // Quickly add Backpack and BikeLight to the cart
            if (mainPage.DisplayedInventoryContainer() == true)
            {
                Navigate("https://www.saucedemo.com/inventory.html");

                mainPage.AddBackpack();

                mainPage.AddBikeLight();

                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Not Logged in.");
            }

            //Act
            // Navigate to cart page and remove first item (Backpack)
            Navigate("https://www.saucedemo.com/cart.html");

            Thread.Sleep(3000);

            cartPage.RemoveBackPack();

            Thread.Sleep(3000);

             //Assert
             // Check if BikeLight is still in cart && if number of items in cart = 1
            Assert.True(cartPage.DisplayedCartItem0Title() && cartPage.CartBadge.Text == "1");

        }

    }
}
