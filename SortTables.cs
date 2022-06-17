using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject
{
    public class SortTables
    {
        IWebDriver driver;
        [SetUp]

     

        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/seleniumPractise/#/offers/");
        }


        [Test]
        public void SortWebTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            //step 1...get all veggie names into arraylist
            //step 2..sort the array list
            //step 3  go and click column
            //step 4 get all veggie names into arraylist B
            //arraylist A TO B = equal

            IList <IWebElement> veggies =driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }

            // step 2 sort this arraylist    -A
            
            foreach(String element in a)
            {
        TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After sorting");
            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            //step3    go and click column
            driver.FindElement(By.CssSelector("th[aria-label*='Veg']")).Click();   
            
            //step 4  get all veggies names into arraylist- B
            ArrayList b = new ArrayList();

       IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }
            //compare Arraylist A TO B =equal
            Assert.AreEqual(a,b);

        }


    }
}
