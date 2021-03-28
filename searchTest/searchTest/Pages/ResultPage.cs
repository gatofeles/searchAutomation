using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchTest.Pages
{
    class ResultPage
    {
        public IWebDriver WebDriver { get; }
        WebDriverWait wait = null;
        public ResultPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement firstCard => wait.Until(e => e.FindElement(By.XPath("//*[@id='mainContent']/div[2]/div/div/div[1]/h4/a")));

        //Checks if some result is displayed
        public bool FirsCardExists()
        {
            return firstCard.Displayed;
        }

        public void clickTheFirstResult()
        {
            firstCard.SendKeys(Keys.Enter);
        }


    }
}
