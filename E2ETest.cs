using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class E2ETest
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
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new String[2];
            String expectedMessage = "Success! Thank you! Your order will be delivered in next few weeks";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@id='signInBtn'][@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
          //  driver.FindElement(By.PartialLinkText("Checkout")).Click();

         IList <IWebElement> products=  driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {                                                                    //title or name of product
                if(expectedProducts.Contains(product.FindElement(By.CssSelector("h4[class='card-title'] a")).Text))
                {
                    product.FindElement(By.CssSelector("button[class='btn btn-info']")).Click();
                    //.card-footer button
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector("h4[class='card-title'] a")).Text);
               
              
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            //check two products added t
            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for(int i= 0; i<checkoutCards.Count; i++){
                //retreive the text to see element on webpage matches element addeed or expected
                //to do that create one more array..actual product from web application

               actualProducts[i]= checkoutCards[i].Text;
            }
            //By lOCator means By. eg By.li
            //compare both products
            Assert.AreEqual(expectedProducts, actualProducts);

            driver.FindElement(By.CssSelector("button[class ='btn btn-success']")).Click();
            driver.FindElement(By.Id("country")).SendKeys("india");

            //wait for country to be vidsible //By Locator means  exact locator
            /// WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();

            //click terms of reference
            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            //same for xpath

            driver.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            //validate message received

      String confirmText= driver.FindElement(By.CssSelector(".alert-dismissible")).Text;

         
            //
           StringAssert.Contains(expectedMessage, confirmText);

            StringAssert.Contains("Success", confirmText);



        }



    }
}
