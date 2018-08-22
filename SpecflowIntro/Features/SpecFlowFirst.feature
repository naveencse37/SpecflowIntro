Feature: SpecFlowFirst
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Default
Scenario: I login to UltimateQA website
	Given I am on ultimate qa login page
	And I have entered <username> and <password>
	When I click login button
	Then I verify the title on homepage

@DataTable
Scenario: I login to UltimateQA website using datatable
	Given I am on ultimate qa login page
	And I have entered valid credentials
	| username              | password |
	| naveencse37@gmail.com | 1234abcd |
	When I click login button
	Then I verify the title on homepage

	
@ScenarioOutline
Scenario Outline: I login to UltimateQA website using scenariooutline
	Given I am on ultimate qa login page
	And I have entered <username> and <password>
	When I click login button
	Then I verify the title on homepage

Examples:
| username              | password |
| naveencse37@gmail.com | 1234abcd |
| test@tester.com       | 1234abcd |

@ScenarioContext
Scenario Outline: I login to UltimateQA website using scenariocontext
	Given I am on ultimate qa login page
	And I have entered <username> and <password>
	When I click login button
	Then I verify the on username on homepage	

Examples:
| username              | password |
| naveencse37@gmail.com | 1234abcd |



  