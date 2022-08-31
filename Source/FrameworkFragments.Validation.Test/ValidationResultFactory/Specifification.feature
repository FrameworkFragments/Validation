Feature: Validation Result Builder
Builder to aggregate together validation outcomes and return them as a single object.

    Scenario: Return an empty validation result
        Given a ValidationResultBuilder
        And the following validation is added
          | ResultType | Label              | Description |
          | Pass       | FULL_NAME_REQUIRED |             |
        Then the current validation result type is Pass
        And the current validation label is "FULL_NAME_REQUIRED"
        And the current validation description is null