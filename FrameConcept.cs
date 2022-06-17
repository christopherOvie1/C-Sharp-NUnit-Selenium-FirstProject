using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class FrameConcept
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
        public void frames()
        {
           IWebElement framescroll= driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);

                //id,name or index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.CssSelector("a[href='lifetime-access'][class='new-navbar-highlighter']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'REST API')]")));
            driver.FindElement(By.XPath("//a[contains(text(),'REST API')]")).Click();
            driver.Navigate().Back();
            //  TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("div.inner-box h1")).Text);
             //driver.SwitchTo().DefaultContent();
            
        }
    }
}
