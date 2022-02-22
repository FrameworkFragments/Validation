Feature: RequiredReference
	Verify the ValidationFailureFactory.RequiredReference function

Scenario: Create a RequiredReference validation failure for 1 field name
	When A RequiredReference Validation failure is created for "Field A"
	Then The current validation failure has validation type "RequiredReference" 
	And The current validation failure developer description contains "Field A"
