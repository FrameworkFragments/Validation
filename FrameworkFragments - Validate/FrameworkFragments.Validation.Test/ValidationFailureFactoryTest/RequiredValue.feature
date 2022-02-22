Feature: RequiredValue
	Verify the ValidationFailureFactory.RequiredValue function

Scenario: Create a RequiredValue validation failure for 1 field name
	When A RequiredValue Validation failure is created for "Field A"
	Then The current validation failure has validation type "RequiredValue" 
	And The current validation failure developer description contains "Field A"
