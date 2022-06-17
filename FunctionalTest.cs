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
    public class FunctionalTest
    {
        IWebDriver driver;

        [SetUp]

        //[Test]

        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }
        [Test]

        public void Dropdown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            IList<IWebElement> radioButtons = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement radBtn in radioButtons)
            {
               if(radioButtons[1].GetDomAttribute("value").Equals("user"))
                {
                    radBtn.Click();
                }
            }
            //complte webelement = driver.FindElement(By.CssSelector("btn btn-success"))
            //By locator =  tn btn-success
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("btn btn-success")));
            driver.FindElement(By.Id("okayBtn")).Click();
         // Boolean result=  driver.FindElement(By.CssSelector("usertype")).Selected;
           // Assert.That(result, Is.True);   
        

        }

    }
}
