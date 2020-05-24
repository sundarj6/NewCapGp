Feature: LoginNegativTest
	I want to select USA GC Site, in Investment Account
	And then
	I want to use a invalid credential to login  
	And then
	I should not be able to login and get a messge as invalid User
@LoginNegativeTest
Scenario Outline: LoginNegativeTest
	Given User at the CG US Ind Inv Site
	Then  User Launches Login Page
	When User enter <username> and <password> 
	Then Invalid user name password unsucessful login messge display
	When Login Button should be displayed
	Then User Closes browser
Examples: 
| username | password |
| sundarj  | test123$ |
| raj  | test123$ |