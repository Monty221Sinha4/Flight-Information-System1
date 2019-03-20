using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Html5;
namespace TestProject1
{
    [TestClass]
    public class TestProject
    {
        [TestMethod]
        public void ChromeMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void FireFoxMethod()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void IEMethod()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Close();
            driver.Quit();
        }
       
    }
}
