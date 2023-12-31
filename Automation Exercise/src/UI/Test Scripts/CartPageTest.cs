﻿using Automation_Exercise.Utilities;

namespace Automation_Exercise.Test_Scripts
{
    [TestFixture]
    [Order(3)]
    public class CartPageTest : BaseTest
    {
        [OneTimeSetUp]
        public void Preconditions()
        {
            suiteTest = extent.CreateTest("Cart Page Tests");
        }
        [Test, Order(1)]
        public void VerifyUserCartIsEmptyWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Cart of nonlogin user is empty.");
            homePage.Open();
            homePage.AssertUserIsLogout();
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
        }
        [Test, Order(2)]
        public void VerifyUserCanAddProductToCartWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Nonlogin user can add product to his cart.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
            cartPage.ContinueToProductPage();
            AdverticeHelper.CheckForAdvertice(driver);
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            productPage.AddProductToCart("Blue Top");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductIsAddedToCart("Blue Top");
        }
        [Test, Order(3)]
        public void VerifyUserCantCheckoutWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Nonlogin user can not checkout.");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            productPage.AddProductToCart("Blue Top");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductListIsNotEmpty();
            cartPage.ContinueToCheckout();
            cartPage.AssertCorrectLoginToAccoutMessageIsDisplayed();
        }
        [Test, Order(4)]
        public void VerifyTotalPriceOfAllAddedProductsAreCorrectWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Total price of all added products are correct without login.");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 350);
            productPage.AddProductToCart("Men Tshirt");
            productPage.ContinueToShopping();
            productPage.AddProductToCart("Blue Top");
            productPage.ContinueToShopping();
            productPage.AddProductToCart("Sleeveless Dress");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            var productNames = cartPage.GetNameOfAllAddedProducts();
            foreach (var product in productNames)
            {
                cartPage.AssertTotalPriceOfProductIsCorrect(product);
            }
        }
        [Test, Order(5)]
        public void VerifyUserCanRemoveProductFromCartWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Nonlogin user can remove product from his cart.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveProductFromOrder("Blue Top");
            cartPage.CheckProductRemoval("Blue Top");
        }
        [Test, Order(6)]
        public void VerifyCanRemoveAllProductFromCartWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Nonlogin user can remove all products from his card.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveAllProductFromOrder();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
            cartPage.ContinueToProductPage();
            AdverticeHelper.CheckForAdvertice(driver);
            productPage.AssertCorrectPageIsLoaded();
        }
        [Test, Order(7)]
        public void VerifyHomeButtonRedirectedToCorrectPageWithoutLogin()
        {
            test = suiteTest.CreateNode("Test Redirected nonlogin user to home page using home button.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.ClickOnHomeButton();
            AdverticeHelper.CheckForAdvertice(driver);
            homePage.AssertCorrectPageIsLoaded();
            homePage.AssertCarouselIsDisplayed();
        }
        [Test, Order(8)]
        public void VerifyLoginUserCartIsEmpty()
        {
            test = suiteTest.CreateNode("Test Cart of login user is empty.");
            UserLogin();
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
        }

        [Test, Order(9)]
        public void VerifyLoginUserCanAddProductToCart()
        {
            test = suiteTest.CreateNode("Test Login user can add product to his cart.");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            productPage.AddProductToCart("Blue Top");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductIsAddedToCart("Blue Top");
        }
        [Test, Order(10)]
        public void VerifyLoginUserCanCheckout()
        {
            test = suiteTest.CreateNode("Test Login user can checkout order.");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            productPage.AddProductToCart("Blue Top");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.AssertProductListIsNotEmpty();
            cartPage.ContinueToCheckout();
            checkoutPage.AssertCorrectPageIsLoaded();
            checkoutPage.AssertAddressesDetailsFormTitleIsDisplayedCorectly();
        }
        [Test, Order(11)]
        public void VerifyLoginUserTotalPriceOfAddedProductIsCorrect()
        {
            test = suiteTest.CreateNode("Test Total price of added products is correct of login user.");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            productPage.AddProductToCart("Blue Top");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 250);
            cartPage.AssertTotalPriceOfProductIsCorrect("Blue Top");
        }
        [Test, Order(12)]
        public void VerifyLoginUserCanRemoveProductFromCart()
        {
            test = suiteTest.CreateNode("Test Login user can remove product from his cart.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveProductFromOrder("Blue Top");
            cartPage.CheckProductRemoval("Blue Top");
        }
        [Test, Order(13)]
        public void VerifyLoginUserTotalPriceOfAllAddedProductsAreCorrect()
        {
            test = suiteTest.CreateNode("Test Total price of all added products is correct of login user. ");
            productPage.Open();
            productPage.AssertCorrectPageIsLoaded();
            ScrollDown(driver, 350);
            productPage.AddProductToCart("Men Tshirt");
            productPage.ContinueToShopping();
            productPage.AddProductToCart("Blue Top");
            productPage.ContinueToShopping();
            productPage.AddProductToCart("Sleeveless Dress");
            productPage.AssertProductAddedSuccessfulTextIsDisplayed();
            productPage.OpenCart();
            cartPage.AssertCorrectPageIsLoaded();
            var productNames = cartPage.GetNameOfAllAddedProducts();
            foreach (var product in productNames)
            {
                cartPage.AssertTotalPriceOfProductIsCorrect(product);
            }
        }
        [Test, Order(14)]
        public void VerifyLoginUserCanRemoveAllProductFromCart()
        {
            test = suiteTest.CreateNode("Test Login user can remove all products from his cart.");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.RemoveAllProductFromOrder();
            cartPage.AssertCorrectEmptyCartMessageIsDisplayed();
        }
        [Test, Order(15)]
        public void VerifyScrollDownFuncionallity()
        {
            test = suiteTest.CreateNode("Test Scrolldown fuctionallity of page");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            ScrollToBottom(driver);
            homePage.AssertCopyRightTextIsDisplayed();
        }
        [Test, Order(16)]
        public void VerifyScrollUpFuncionallity()
        {
            test = suiteTest.CreateNode("Test Scrollup fuctionallity of page");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            ScrollToBottom(driver);
            homePage.ClickOnScrollUpButton();
            homePage.AssertWebsiteLogoIsDisplayed();
        }
        [Test, Order(17)]
        public void VerifyHomeButtonRedirectUserToCorrectPage()
        {
            test = suiteTest.CreateNode("Test home button redirect user to home page. ");
            cartPage.Open();
            cartPage.AssertCorrectPageIsLoaded();
            cartPage.ClickOnHomeButton();
            AdverticeHelper.CheckForAdvertice(driver);
            homePage.AssertCorrectPageIsLoaded();
            homePage.AssertCorrectCarouselTextsAreDisplayed();
        }
    }
}