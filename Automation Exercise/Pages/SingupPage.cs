﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Exercise.Pages
{
    public class SingupPage : BasePage
    {
        public SingupPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageURL => "https://www.automationexercise.com/signup";
        public IWebElement titleMrRadioButton => driver.FindElement(By.XPath("//input[@id='id_gender1']"));
        public IWebElement titleMrsRadioButton => driver.FindElement(By.XPath("//input[@id='id_gender2']"));
        public IWebElement nameField => driver.FindElement(By.XPath("//input[@id='id_gender2']"));
        public IWebElement emailField => driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement passwordField => driver.FindElement(By.XPath("//input[@id='password']"));
        public IWebElement dayOfBirthDropDown => driver.FindElement(By.XPath("//select[@id='days']"));
        public IWebElement monthOfBirthDropDown => driver.FindElement(By.XPath("//select[@id='months']"));
        public IWebElement yearOfBirthDropDown => driver.FindElement(By.XPath("//select[@id='years']"));
        public IWebElement newsLetterCheckbox => driver.FindElement(By.XPath("//input[@id='newsletter']"));
        public IWebElement receiveOffersCheckbox => driver.FindElement(By.XPath("//input[@id='optin']"));
        public IWebElement firstNameField => driver.FindElement(By.XPath("//input[@id='first_name']"));
        public IWebElement lastNameField => driver.FindElement(By.XPath("//input[@id='last_name']"));
        public IWebElement addressField => driver.FindElement(By.XPath("//input[@id='address1']"));
        public IWebElement address2Field => driver.FindElement(By.XPath("//input[@id='address2']"));
        public IWebElement stateField => driver.FindElement(By.XPath("//input[@id='state']"));
        public IWebElement cityField => driver.FindElement(By.XPath("//input[@id='city']"));
        public IWebElement zipCodeField => driver.FindElement(By.XPath("//input[@data-qa='zipcode']"));
        public IWebElement mobileNumberField => driver.FindElement(By.XPath("//input[@id='mobile_number']"));
        public IWebElement createAccountButton => driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
    }
}
