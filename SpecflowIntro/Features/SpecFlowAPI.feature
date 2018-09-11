Feature: First API test
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@API
Scenario Outline: Add Cart
	#Given I query the API
    Then I add <item> to cart 
Examples:
| item  |
| spoon |
