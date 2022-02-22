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
				"A required VALUE is missing for (" + String.Join(", ", fieldNames) + ")"
			);
		}
    }
}
