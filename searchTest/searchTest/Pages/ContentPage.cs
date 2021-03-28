using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace searchTest.Pages
{
    class ContentPage
    {
        public IWebDriver WebDriver { get; }
        IReadOnlyList<IWebElement> bodyText = null;
        IReadOnlyList<IWebElement> bodyTitles = null;
        WebDriverWait wait = null;

        public ContentPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement contentTitle => wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div[5]/div[2]/div/div/div/div/div/h1")));
        public IWebElement contentBody => wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div[5]/main/div/div/div[1]/article")));

        //Checks if the keyword is in the title of the result
        public bool isWordInTitle(string keyword)
        {
            if (contentTitle.Text.ToLower().Contains(keyword))
            {
                return true;
            }
            return false;
        }

        //Checks if the keyword is in the body text of the result
        public bool isWordInBody(string keyword)
        {
            bodyText = contentBody.FindElements(By.TagName("p"));
            bodyTitles = contentBody.FindElements(By.TagName("h2"));

            //checks if the keyword is in the body text in paragraphs
            foreach (IWebElement paragraph in bodyText)
            {
                string text = paragraph.Text.ToLower();

                if (text.Contains(keyword))
                {
                    return true;
                }

            }

            //checks if the keyword is in the body text in headings 2
            foreach (IWebElement title in bodyTitles)
            {
                string text = title.Text.ToLower();

                if (text.Contains(keyword))
                {
                    return true;
                }

            }

            return false;
        }

    }
}
