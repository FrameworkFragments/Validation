namespace FrameworkFragments.Validation;

public class ValidationResult : IValidationResult
{
  public ValidationResult(ValidationResultType validationResultType, string label, string description)
  {
    ResultType = validationResultType;
    Label = label;
    Description = description;
  }

  public string Description { get; }

  public ValidationResultType ResultType { get; }

  bool IValidationResult.IsPassed => ValidationResultType.Pass == ResultType;

  bool IValidationResult.IsFailed => ValidationResultType.Fail == ResultType;

  public string Label { get; }
}