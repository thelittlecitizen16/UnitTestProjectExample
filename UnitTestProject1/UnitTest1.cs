using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver initWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("ignore-certificate-errors");
            ChromeDriver driver = new ChromeDriver(@"C:\", options);
            return driver;
        }
         


        [TestMethod]
        public void TestMethod1()
        {
              IWebDriver driver = initWebDriver();
              WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

             driver.Navigate().GoToUrl("https://www.google.com");

            var iframe = driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
            iframe.FindElement(By.CssSelector("#introAgreeButton > span > span")).Click();
            wait.Until(d => d.FindElement(By.CssSelector(".RNNXgb .SDkEP .a4bIc")));
            driver.FindElement(By.CssSelector(".RNNXgb .SDkEP .a4bIc .gLFyf ")).SendKeys("twitter");
            driver.FindElement(By.CssSelector("input[name='btnK']")).Click();
            wait.Until(d => d.FindElement(By.CssSelector("a[href='https://twitter.com/?lang=nl']")));
            driver.FindElement(By.CssSelector("a[href='https://twitter.com/?lang=nl']")).Click();
            wait.Until(d => d.FindElement(By.CssSelector("#react-root > div > div > div > main > div > div > div.css-1dbjc4n.r-13awgt0.r-1euycsn.r-tv6buo > div:nth-child(1) > div.css-1dbjc4n.r-1kihuf0.r-17w48nw > div.css-901oao.r-hkyrab.r-1qd0xha.r-1ra0lkn.r-vw2c0b.r-ad9z0x.r-1x0uki6.r-bcqeeo.r-qvutc0 > span")));
            string title = driver.FindElement(By.CssSelector("#react-root > div > div > div > main > div > div > div.css-1dbjc4n.r-13awgt0.r-1euycsn.r-tv6buo > div:nth-child(1) > div.css-1dbjc4n.r-1kihuf0.r-17w48nw > div.css-901oao.r-hkyrab.r-1qd0xha.r-1ra0lkn.r-vw2c0b.r-ad9z0x.r-1x0uki6.r-bcqeeo.r-qvutc0 > span")).Text;
          
            string expectedTitle = "Bekijk wat er nu in de wereld gebeurt";

            Assert.AreEqual(expectedTitle, title);

            driver.Quit();
        }
    }
}
