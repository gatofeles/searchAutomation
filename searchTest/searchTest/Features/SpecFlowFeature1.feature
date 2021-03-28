Feature: Search Functionality
	Searching for content through keywords

@mytag
Scenario: Search for  content related to the word card in a  1200 x 754 px
 viewport size using Google Chrome.

	Given that I visit the WEX Website
	And I click the search icon
	Then the search form should appear
	When I type the keyword card
	And click the icon for running the search
	Then the search results should be shown
	When I check the title of the first result
	And I check the body of the result
	Then the word card should be part of the search result
