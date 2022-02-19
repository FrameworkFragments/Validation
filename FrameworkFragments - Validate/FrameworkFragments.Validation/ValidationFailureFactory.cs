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

    }
}
