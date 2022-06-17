using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class AlertActionsAutoSuggestive
    {
        IWebDriver driver;

        [SetUp]


        public void LaunchBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");

        }
        [Test]
        public void test_Alert()
        {
            String name = "chris";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfi']")).Click();
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //  driver.SwitchTo().Alert().Dismiss();
            // driver.SwitchTo().Alert().SendKeys("hello");
            StringAssert.Contains(name, alertText);

        }
        [Test]
        public void AutoSuggestiveDropdown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("Ind");
           // Thread.Sleep(3000);

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                    Thread.Sleep(3000);
                }
            }
           TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
            }
        [Test]
        public void test_Actions()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/#/index");
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector(".nav-outer .dropdown-toggle"))).Build().Perform();
            // driver.FindElement(By.XPath("//ul[@class='dropdown-menu' ]/li[1]/a")).Click();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu' ]/li[1]/a"))).DoubleClick().Perform();
        }
        [Test]
        public void test_ActionsDragAndDrop()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")),driver.FindElement(By.Id("droppable"))).Perform(); 
            
        }

    }
    }
