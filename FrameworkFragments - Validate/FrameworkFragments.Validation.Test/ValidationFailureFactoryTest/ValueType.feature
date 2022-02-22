Feature: ValueType
	Verify the ValidationFailureFactory.ValueType function

Scenario: Create a ValueType validation failure for 1 field name
	When A ValueType Validation failure is created for "Field A"
	Then The current validation failure has validation type "ValueType" 
	And The current validation failure developer description contains "Field A"
