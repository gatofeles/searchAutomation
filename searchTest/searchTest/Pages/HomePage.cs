using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace searchTest.Pages
{
    class HomePage
    {

        public IWebDriver WebDriver { get; }
        WebDriverWait wait = null;
        public HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement searchButton => wait.Until(e => e.FindElement(By.XPath("//*[@id='mega-menu-item-439']/a")));
        public IWebElement searchField => wait.Until(e => e.FindElement(By.Id("s")));
        public IWebElement runSearchBtn => wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div[5]/div[1]/div/div/div/form/div/button"))); 

        public void clickSearchBtn()
        {
            searchButton.Click();
            
        }

        public void clickSearchForm()
        {
            searchField.Click();
        }

        public bool searchFormExists()
        {
            return searchButton.Displayed;
        }

        public void typeInSearchForm(String word)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            searchField.SendKeys(word);
        }

        public void runSearch()
        {
            runSearchBtn.SendKeys(Keys.Enter);
        }
    }
}
