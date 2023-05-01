Feature: Navigate to Albums page

Background:
	Given I am on the home page
	When I click Discover

@TC1
Scenario: Checking album page 
	When I click Albums
	Then the "ALBUMS" page is displayed
@TC2
Scenario: Choosing an album  
	Given I am on the Albums page
	When I click a random Album
	Then the selected album is displayed
