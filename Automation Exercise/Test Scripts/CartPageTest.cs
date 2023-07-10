﻿using Automation_Exercise.Utilities;

namespace Automation_Exercise.Test_Scripts
{
    public class CartPageTest : BaseTest
    {
        [Test,Order(1)]
        public void VerifyUserCantCheckoutWithoutLogin()
        {
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            productPage.AddProductToCart("Blue Top");
            Thread.Sleep(1000);
            //TODO BASEPAGE
            productPage.AssertCorrectSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductListIsNotEmpty();
            cartPage.ContinueToCheckout();
            cartPage.AssertCorrectLoginToAccoutMessageIsDisplayed();
        }
        [Test,Order(2)]
        public void VerifyUserCanRemoveProductFromCart()
        {
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveProductFromOrder("Blue Top");
            cartPage.CheckProductRemoval("Blue Top");
        }
        [Test,Order(3)]
        public void VerifyUserCanRemoveAllProductFromCart()
        {
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveAllProductFromOrder();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
            cartPage.ContinueToProductPage();
            AdverticeHelper.CheckForAdvertice(driver);
            productPage.AssertCorrectPageIsLoaded();
        }
        [Test, Order(4)] //TODO
        public void VerifyUserCanAddProductToCartWithoutLogin()
        {
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
            cartPage.ContinueToProductPage();
            productPage.AssertCorrectPageIsLoaded();
            productPage.AddProductToCart("Blue Top");
            Thread.Sleep(1000);
            //TODO BASEPAGE
            productPage.AssertCorrectSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductIsAddedToCart("Blue Top");
        }
    }
}
