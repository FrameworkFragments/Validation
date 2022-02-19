Feature: Uniqueness
	Verify the ValidationFailureFactory.Uniqueness function

Scenario: Create a Uniqueness validation failure for 1 field name
	When A Uniqueness Validation failure is created for "Field A"
	Then The current validation failure has validation type "Uniqueness" 
	And The current validation failure developer description contains "Field A"
