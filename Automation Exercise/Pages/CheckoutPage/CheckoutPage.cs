﻿using Automation_Exercise.Utilities;
using OpenQA.Selenium;
using System.Reflection.Metadata;

namespace Automation_Exercise.Pages.CheckoutPage
{
    public partial class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageURL => "https://www.automationexercise.com/checkout";
        public int CalculateTotalPriceForProduct(string productName)
        {
            foreach (var product in orderProducts)
            {
                string nameOfProduct = product.FindElement(By.XPath("//*[@class='cart_description']//a")).Text;
                if (productName == nameOfProduct)
                {
                    int productPrice = int.Parse(product.FindElement(By.XPath("//*[@class='cart_price']/p")).Text.Split(null)[1]);
                    int productQuantity = int.Parse(product.FindElement(By.XPath("//*[@class='cart_quantity']/button")).Text);
                    int productTotalPrice = int.Parse(product.FindElement(By.XPath("//*[@class='cart_total']/p")).Text.Split(null)[1]);
                    if (productPrice * productQuantity == productTotalPrice)
                    {
                        return productPrice;
                    }
                }
            }
            return 0;
        }
        public int TotalPriceCalculation()
        {
            int totalPrice = 0;
            foreach (var product in orderProducts)
            {
                int productTotalPrice = int.Parse(product.FindElement(By.XPath("//*[@class='cart_total']/p")).Text.Split(null)[1]);
                totalPrice += productTotalPrice;
            }
            return totalPrice;
        }

        public int OrderTotalAmount() => int.Parse(orderTotalAmount.Text.Split(null)[1]);
        public void WriteCommentMessage(string commentMessage) => commentArea.SendKeys(commentMessage);
        public void PlaceOrder() => placeOrderButton.Click();
        private bool CheckIfProductIsAdded(string productName)
        {
            foreach (var product in orderProducts)
            {
                if (product.FindElement(By.XPath("//*[@class='cart_description']//a")).Text == productName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
