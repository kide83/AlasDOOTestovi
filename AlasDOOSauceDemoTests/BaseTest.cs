using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace AlasDOOSauceDemoTests
{
    public class BaseTest : IDisposable
    {
        protected bool disposed;
        protected IWebDriver Driver;
        protected IWebElement element;

        public BaseTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        protected void Navigate()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        protected void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Driver.Quit();
            }

            disposed = true;
        }

        ~BaseTest()
        {
            Dispose(false);
        }
    }
}