using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace HomeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = new FirefoxDriver();
            var driver =GetChormeDriver();
            driver.Navigate().GoToUrl("http//www.facebook.com");
        }

        private IWebDriver GetChormeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
            

            IWebElement parentElement = driver.FindElement(By.ClassName("button"));
            IWebElement childElement = parentElement.FindElement(By.Id("submit"));
            childElement.Submit();
            

        }
    }
}
