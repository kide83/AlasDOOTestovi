using OpenQA.Selenium;

namespace AlasDOOSauceDemoTests.POMs
{
    public class CartPage
    {
        private IWebDriver driver { get; }

        public CartPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement RemoveBackPackButton => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement RemoveTShirtButton => driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));
        public IWebElement RemoveBikeLightButton => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement CartBadge => driver.FindElement(By.ClassName("shopping_cart_link"));
        public IWebElement CheckouButton => driver.FindElement(By.Id("checkout"));

        public bool DisplayedRemoveBackPackButton() => RemoveBackPackButton.Displayed;
        public bool DisplayedRemoveTShirtButton() => RemoveTShirtButton.Displayed;
        public bool DisplayedRemoveBikeLightButton() => RemoveBikeLightButton.Displayed;
        public bool DisplayedCartBadge() => CartBadge.Displayed;
        public bool DisplayedCheckouButton() => CheckouButton.Displayed;

        public IWebElement CartItem0Title => driver.FindElement(By.Id("item_0_title_link"));
        public IWebElement CartItem1Title => driver.FindElement(By.Id("item_1_title_link"));
        public IWebElement CartItem2Title => driver.FindElement(By.Id("item_2_title_link"));
        public IWebElement CartItem3Title => driver.FindElement(By.Id("item_3_title_link"));
        public IWebElement CartItem4Title => driver.FindElement(By.Id("item_4_title_link"));
        public IWebElement CartItem5Title => driver.FindElement(By.Id("item_5_title_link"));

        public bool DisplayedCartItem0Title() => CartItem0Title.Displayed;
        public bool DisplayedCartItem1Title() => CartItem1Title.Displayed;
        public bool DisplayedCartItem2Title() => CartItem2Title.Displayed;
        public bool DisplayedCartItem3Title() => CartItem3Title.Displayed;
        public bool DisplayedCartItem4Title() => CartItem4Title.Displayed;
        public bool DisplayedCartItem5Title() => CartItem5Title.Displayed;

        public void RemoveBackPack()
        {
            RemoveBackPackButton.Click();
        }

        public void GoToCheckoutPage()
        {
            CheckouButton.Click();
        }
        
    }
}
