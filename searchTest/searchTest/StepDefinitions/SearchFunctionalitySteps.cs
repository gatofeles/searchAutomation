using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using searchTest.Pages;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace searchTest.StepDefinitions
{
    [Binding]
    public class SearchFunctionalitySteps
    {

        //Setting up the test environment
        IWebDriver webDriver = null; 
        HomePage homePage = null;
        ResultPage resultPage = null;
        ContentPage contentPage = null;
        bool wordInTitle = false;
        bool wordInBody = false;
        string keyword = "card";
        ChromeOptions chromeOptions = new ChromeOptions();
       

        [Given(@"that I visit the WEX Website")]
        public void GivenThatIVisitTheWEXWebsite()
        {
            //setting the screen to 1200 x 754 px
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string webdriver = sCurrentDirectory + "/webdriver";
            chromeOptions.AddArgument("--window-size=1200,754");
            webDriver = new ChromeDriver(@"..\searchAutomation\searchTest\searchTest\webdriver\",chromeOptions);
            webDriver.Navigate().GoToUrl("https://www.wexinc.com/");
        }
        
        [Given(@"I click the search icon")]
        public void GivenIClickTheSearchIcon()
        {
            homePage = new HomePage(webDriver);
            homePage.clickSearchBtn();
        }
        
        [When(@"I type the keyword card")]
        public void WhenTypeTheKeywordCard()
        {
            homePage.typeInSearchForm(keyword);
        }
        
        [When(@"click the icon for running the search")]
        public void WhenClickTheIconForRunningTheSearch()
        {
            homePage.runSearch();
        }
        
        [When(@"I check the title of the first result")]
        public void WhenICheckTheTitleOfTheFirstResult()
        {
            contentPage = new ContentPage(webDriver);
            resultPage.clickTheFirstResult();
            wordInTitle = contentPage.isWordInTitle(keyword);
        }
        
        [When(@"I check the body of the result")]
        public void WhenICheckTheBodyOfTheResult()
        {
            wordInBody = contentPage.isWordInBody(keyword);
        }
        
        [Then(@"the search form should appear")]
        public void ThenTheSearchFormShouldAppear()
        {
            Assert.That(homePage.searchFormExists(), Is.True);
        }
        
        [Then(@"the search results should be shown")]
        public void ThenTheSearchResultsShouldBeShown()
        {
            resultPage = new ResultPage(webDriver);
            Assert.That(resultPage.FirsCardExists(), Is.True);
        }
        
        [Then(@"the word card should be part of the search result")]
        public void ThenTheWordCardShouldBePartOfTheSearchResult()
        {
            Assert.That(wordInBody || wordInTitle, Is.True);
            webDriver.Close();
        }
    }
}
