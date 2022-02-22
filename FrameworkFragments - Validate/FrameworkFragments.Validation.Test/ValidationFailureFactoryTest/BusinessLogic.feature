Feature: BusinessLogic
	Verify the ValidationFailureFactory.BusinessLogic function

Scenario: Create a BusinessLogic validation failure for 1 field name
	When A BusinessLogic Validation failure is created for "Field A"
	Then The current validation failure has validation type "BusinessLogic" 
	And The current validation failure developer description contains "Field A"
