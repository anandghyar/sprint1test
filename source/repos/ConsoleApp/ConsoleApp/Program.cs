using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            
            driver.Manage().Window.Maximize();
            String target_xpath = "//h3[.='LambdaTest: Cross Browser Testing Tools | Free Automated ...']";
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            
            driver.FindElement(By.Name("q")).SendKeys("LambdaTest" + Keys.Enter);
            
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath)));
           /SearchResult.Click();
        }
    }
}
