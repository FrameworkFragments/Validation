using System;
using System.Collections.Generic;

namespace FrameworkFragments.Validation
{
    public class ValidationFailureFactory
    {
	    private static ValidationFailureFactory _singleton;
	    public static ValidationFailureFactory Singleton => _singleton ??= new ValidationFailureFactory();

	    public IValidationFailure Uniqueness(IEnumerable<string> fieldNames)
        {
            return new ValidationFailure(
                ValidationType.Uniqueness,
                @"UNIQUE_VALUE_REQUIRED",
                "The values provided for ("+ String.Join(", ", fieldNames)+") must be unique"
                );
        }

	    public IValidationFailure RequiredReference(IEnumerable<string> fieldNames)
	    {
		    return new ValidationFailure(
			    ValidationType.RequiredReference,
			    @"REQUIRED_REFERENCE_MISSING",
			    "A required reference is missing for (" + String.Join(", ", fieldNames) + ")"
		    );
        }

	    public IValidationFailure RequiredValue(IEnumerable<string> fieldNames)
	    {
			return new ValidationFailure(
				ValidationType.RequiredValue,
				@"REQUIRED_VALUE_MISSING",
				"A required Value is missing for (" + String.Join(", ", fieldNames) + ")"
			);
		}

	    public IValidationFailure ValueRange(IEnumerable<string> fieldNames)
	    {
			return new ValidationFailure(
				ValidationType.ValueRange,
				@"VALUE_OUT_OF_RANGE",
				"Value is out of range for (" + String.Join(", ", fieldNames) + ")"
			);
		}

	    public IValidationFailure ValueType(IEnumerable<string> fieldNames)
	    {
			return new ValidationFailure(
				ValidationType.ValueType,
				@"INCORRECT_VALUE_TYPE",
				"Incorrect value type for (" + String.Join(", ", fieldNames) + ")"
			);
		}

	    public IValidationFailure BusinessLogic(IEnumerable<string> fieldNames)
	    {
			return new ValidationFailure(
				ValidationType.BusinessLogic,
				@"INVALID_BUSINESS_LOGIC",
				"Invalid business logic for (" + String.Join(", ", fieldNames) + ")"
			);
		}
    }
}
