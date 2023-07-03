﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Automation_Exercise.Utilities;

namespace Automation_Exercise.Pages
{
    public abstract class BasePage
    {
        private int elementsTimeout = 5;
        protected IWebDriver driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(elementsTimeout));
        }
        public IWebElement homeLink => driver.FindElement(By.XPath("//a[contains(text(),'Home')]"));
        public IWebElement productsLink => driver.FindElement(By.XPath("//a[contains(@href,'/products')]"));
        public IWebElement cartLink => driver.FindElement(By.XPath("//a[contains(@href,'/view cart')]"));
        public IWebElement loginLink => driver.FindElement(By.XPath("//a[contains(@href,'/login')]"));
        public IWebElement logoutLink => driver.FindElement(By.XPath("//a[contains(@href,'/logout')]"));
        public IWebElement deleteAccountLink => driver.FindElement(By.XPath("//a[contains(@href,'/delete account')]"));
        public IWebElement contactusLink => driver.FindElement(By.XPath("//a[contains(@href,'/contact us')]"));
        public IWebElement usernameLogin => driver.FindElement(By.XPath($"//*[@class='nav navbar-nav']//b[contains(text(), '{Constants.firstName} {Constants.lastName}')]"));
        
        public IWebElement logoHomeLink => driver.FindElement(By.XPath("//*[src='/static/images/home/logo.png']"));
        public IWebElement subscribeField => driver.FindElement(By.XPath("//input[@id='susbscribe_email']"));
        public IWebElement subscribeButton => driver.FindElement(By.XPath("//button[@id='susbscribe']"));
        protected WebDriverWait waitDriver { get; set; }
        public abstract string PageURL { get; }
        public void Open() => driver.Navigate().GoToUrl(PageURL);
        public string GetPageTitle() => driver.Title;

    }
}