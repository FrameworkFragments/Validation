Feature: ValueRange
	Verify the ValidationFailureFactory.ValueRange function

Scenario: Create a ValueRange validation failure for 1 field name
	When A ValueRange Validation failure is created for "Field A"
	Then The current validation failure has validation type "ValueRange" 
	And The current validation failure developer description contains "Field A"
