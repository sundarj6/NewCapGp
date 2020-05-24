Feature: AddTrackerTest
	As a user I navigate to Capital Group US Invididual Investment Page 
	And navigate to Symbols and Fund Numbers Page
	And select 'AMCAP Fund' and 'New World Fund'for tracking 
	By clicking 'Add to Tracker' button
	As I am not logged in 
	I should be redirected to Login Page
@mytag
Scenario: AddTrackTest
    Given User at US_InvestPage
	Given User Navigates to Symbols Page 
	When select the AMCAP Fund and New World Fund
	And  clicks AddToTracker
	Then Login Page is displayed
	Then Close Browser