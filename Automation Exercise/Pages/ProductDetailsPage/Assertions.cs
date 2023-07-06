﻿namespace Automation_Exercise.Pages.ProductDetailsPage
{
    partial class ProductDetailsPage
    {
        public void AssertCorrectPageIsLoaded()
        {
            Assert.AreEqual("Automation Exercise - Product Details", GetPageTitle());
        }
        public void AssertProductPictureIsDisplayed()
        {
            Assert.True(productPicture.Displayed);
        }
        public void AssertCorrectProductDetailsPageIsOpened(string productId)
        {
            Assert.AreEqual(GeneratePageDetailsUrl(productId), GetPageUrl());
        }
        //TODO
    }
}

