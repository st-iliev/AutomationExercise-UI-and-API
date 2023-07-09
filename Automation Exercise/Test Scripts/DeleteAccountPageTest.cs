﻿using Automation_Exercise.Utilities;

namespace Automation_Exercise.Test_Scripts
{
    public class DeleteAccountPageTest : BaseTest
    {
        [Test]
        public void VerifyDeleteUserAccount()
        {
            loginPage.Open();
            loginPage.AssertCorrectPageIsLoaded();
            loginPage.AssertCorrectLoginFormTitleIsDisplayed();
            loginPage.FillLoginForm(Constants.email, Constants.password);
            loginPage.ClickOnLoginButton();
            homePage.AssertUserIsLogin();
            homePage.DeleteAccount();
            AdverticeHelper.CheckForAdvertice(driver);
            deleteAccountPage.AssertCorrectPageIsLoaded();
            deleteAccountPage.AssertCorrectAccountDeleteMessageIsDisplayed();
            deleteAccountPage.AssertCorrectAccountDeletedSuccessfullMessageIsDisplayed();
            deleteAccountPage.AssertCorrectSecondAccountDeletedSuccessfullMessageIsDisplayed();
            deleteAccountPage.ClickOnContinue();
            homePage.AssertCorrectPageIsLoaded();
            homePage.AssertUserIsLogout();
        }
    }
}