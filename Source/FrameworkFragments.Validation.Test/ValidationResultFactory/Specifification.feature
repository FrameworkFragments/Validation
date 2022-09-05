Feature: Validation Result Builder
Builder to aggregate together validation outcomes and return them as a single object.

    Scenario: Simple Passing Validation
        Given a ValidationResultBuilder
        And the following validation is added
          | ResultType | Label              | Description |
          | Pass       | FULL_NAME_REQUIRED |             |
        When the ValidationResults are Built
        Then the current ValidationResults has no errors
        Then the current validation result type is Pass
        And the current validation label is "FULL_NAME_REQUIRED"
        And the current validation description is null

    Scenario: Simple Failing Validation
        Given a ValidationResultBuilder
        And the following validation is added
          | ResultType | Label              | Description      |
          | Fail       | FULL_NAME_REQUIRED | Test Description |
        When the ValidationResults are Built
        Then the current ValidationResults has 1 error
        Then the current validation result type is Pass
        And the current validation label is "FULL_NAME_REQUIRED"
        And the current validation description is "Test Description"