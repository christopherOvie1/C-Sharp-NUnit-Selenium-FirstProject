using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class WindowHandle
    {

        IWebDriver driver;

        [SetUp]
        public void LaunchBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");

        }
        [Test]
        public void WindleHandles()
        {
            String email = "mentor@rahulshettyacademy.com";
          String parentWindowId=  driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector("a[class='blinkingText']")).Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            //driver.SwitchTo().Window(driver.WindowHandles[0]);
          String childWindowName=  driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
         //TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
         String text=  driver.FindElement(By.CssSelector(".red")).Text;
            TestContext.Progress.WriteLine(text);

                String [] splittedText=text.Split("at");
         String  []trimmedString = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedString[0]);
            driver.SwitchTo().Window(parentWindowId);


            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);
            //driver.FindElement(By.Id("password")).SendKeys("learning");
          //  driver.FindElement(By.XPath("//input[@id='signInBtn'][@type='submit']")).Click();






        }
    }
}
