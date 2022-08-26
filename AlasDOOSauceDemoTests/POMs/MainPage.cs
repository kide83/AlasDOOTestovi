using OpenQA.Selenium;

namespace AlasDOOSauceDemoTests.POMs
{
    public class MainPage
    {
        private IWebDriver driver { get; }

        public MainPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement InventoryContainer => driver.FindElement(By.Id("inventory_container"));
        public IWebElement BackpackButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement BikeLightButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement TShirtButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement CartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));
        public IWebElement BikeLightPageLink => driver.FindElement(By.Id("item_0_title_link"));

        public bool DisplayedInventoryContainer() => InventoryContainer.Displayed;
        public bool DisplayedBackpackButton() => BackpackButton.Displayed;
        public bool DisplayedBikeLightButton() => BikeLightButton.Displayed;
        public bool DisplayedTShirtButton() => TShirtButton.Displayed;
        public bool DisplayedCartBadge() => CartBadge.Displayed;
        public bool DisplayedBikeLightPageLink() => BikeLightPageLink.Displayed;

        public void AddBackpack()
        {
            BackpackButton.Click();
        }

        public void AddBikeLight()
        {
            BikeLightButton.Click();
        }

        public void AddTShirt()
        {
            TShirtButton.Click();
        }

        public void OpenBikeLightProductPage()
        {
            BikeLightPageLink.Click();
        }

    }
}
