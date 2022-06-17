using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class FirstSeleniumTest
    {
        IWebDriver driver;

        [SetUp]

        //[Test]

        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }
        [Test]

        public void EndToEndFlow()
        {

        }
    }
}
