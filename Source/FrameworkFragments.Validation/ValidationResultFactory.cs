using System;
using System.Collections.Generic;

namespace FrameworkFragments.Validation;

public class ValidationResultFactory
{
  private static ValidationResultFactory _singleton;
  public static ValidationResultFactory Singleton => _singleton ??= new ValidationResultFactory();

  public IValidationResult SimpleValidation(ResultType resultType, string label, string description)
  {
    return new SimpleValidationResult(resultType, label, description);
  }
}