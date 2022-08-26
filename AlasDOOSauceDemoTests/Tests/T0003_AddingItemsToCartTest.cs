using AlasDOOSauceDemoTests.POMs;
using System;
using System.Threading;
using Xunit;

namespace AlasDOOSauceDemoTests.Tests
{
    public class T0003_AddingItemsToCartTest : BaseTest
    {

        private readonly LoginPage logInPage;
        private readonly MainPage mainPage;
        private readonly InventoryItemPage inventoryItemPage;
        private readonly CartPage cartPage;

        public T0003_AddingItemsToCartTest()
        {
            logInPage = new LoginPage(Driver);
            mainPage = new MainPage(Driver);
            inventoryItemPage = new InventoryItemPage(Driver);
            cartPage = new CartPage(Driver);
        }

        [Fact(DisplayName = "Test: Adding First Item to The Basket")]
        public void AddingFirstItemToBasketCheck()
        {
            
            //Arrange
            Navigate();

            var username_input = "standard_user";
            var password_input = "secret_sauce";

            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);

            //Act
            // If we are loggedin and on main shop page => add first item (Backpack) to the cart
            if (mainPage.DisplayedInventoryContainer() == true)
            {
                Navigate("https://www.saucedemo.com/inventory.html");

                mainPage.AddBackpack();

                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Not Logged in.");
            }

            Thread.Sleep(3000);

            //Assert
            Assert.Equal("1", mainPage.CartBadge.Text);

        }


        [Fact(DisplayName = "Test: Adding Second Item to The Basket + Checking if Items are Different")]
        public void AddingSecondItemToBasketCheck()
        {
            //Arrange
            Navigate();

            var username_input = "standard_user";
            var password_input = "secret_sauce";

            logInPage.LogIn(username_input, password_input);

            Thread.Sleep(3000);

            // If we are loggedin and on main shop page => add first item (Backpack) to the cart
            if (mainPage.DisplayedInventoryContainer() == true)
            {
                Navigate("https://www.saucedemo.com/inventory.html");

                mainPage.AddBackpack();

                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Not Logged in.");
            }

            //Act
            // If Backpack is already added => navigate to second item (BikeLight) details page and add it to the cart
            if (inventoryItemPage.CartBadge.Text == "1")
            {

                mainPage.OpenBikeLightProductPage();

                Thread.Sleep(3000);

                inventoryItemPage.AddBikeLight();

                Thread.Sleep(3000);

            }
            else
            {
                Console.WriteLine("First Item Was Not Added Succesfully");
            }

            //Assert
            // Navigate to cart page to make sure Item 1 and Item 2 are different
            Navigate("https://www.saucedemo.com/cart.html");

            Thread.Sleep(3000);

            Assert.True(cartPage.CartItem0Title != cartPage.CartItem4Title);

        }

    }
}
