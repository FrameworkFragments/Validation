using System.Reflection;

namespace FrameworkFragments.Validation.Test;

public class Example
{
  private const string XMustBeLessThanYLabel = "X_MUST_BE_LESS_THAN_Y";
  private const string YMustNotEqualZ = "Y_MUST_NOT_EQUAL_Z";

  public ValidateResponse Validate(int x, int y, int z)
  {
    var validationResultBuilder = new ValidationResults.Builder();
    validationResultBuilder.Add(() => ValidateXGreaterThanY(x, y)).Add(() => ValidateYDoesNotEqualZ(y, z));

    return new ValidateResponse(MethodBase.GetCurrentMethod()?.Name ?? string.Empty, validationResultBuilder.Build());
  }

  public IValidationResult ValidateXGreaterThanY(int x, int y)
  {
    if (x > y)
      return Validation.ValidationResultFactory.Singleton.SimpleValidation(ValidationResultType.Pass,
        XMustBeLessThanYLabel, string.Empty);

    return Validation.ValidationResultFactory.Singleton.SimpleValidation(ValidationResultType.Fail,
      XMustBeLessThanYLabel, $"The value {x} must be greater than {y}");
  }

  public IValidationResult ValidateYDoesNotEqualZ(int y, int z)
  {
    if (y != z)
      return Validation.ValidationResultFactory.Singleton.SimpleValidation(ValidationResultType.Pass, YMustNotEqualZ,
        string.Empty);

    return Validation.ValidationResultFactory.Singleton.SimpleValidation(ValidationResultType.Fail, YMustNotEqualZ,
      $"The value {y} must be greater than {z}");
  }
}

public class ValidateResponse
{
  public ValidateResponse(string responseSource, IValidationResults validationResults)
  {
    ResponseSource = responseSource;
    ValidationResults = validationResults;
  }

  public string ResponseSource { get; }
  public IValidationResults ValidationResults { get; }
}