﻿using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Automation_Exercise.Utilities
{
    public static class AdverticeHelper
    {
        public static void CheckForAdvertice(IWebDriver driver)
        {
            string parentWindowHandle = driver.CurrentWindowHandle;
            if (driver.Url.EndsWith("#google_vignette"))
            {
                driver.Navigate().GoToUrl($"{driver.Url}#google_vignette");
                driver.SwitchTo().Window(parentWindowHandle);
            }
        }
    }
}