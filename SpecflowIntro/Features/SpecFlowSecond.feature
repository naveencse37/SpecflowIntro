Feature: SpecFlowSecond
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
#tEST
@Default
Scenario: I login to UltimateQA website
	Given I am on ultimate qa login page
	And I have entered <username> and <password>
	When I click login button
	Then I verify the title on homepage




  