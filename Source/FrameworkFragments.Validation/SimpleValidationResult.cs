namespace FrameworkFragments.Validation;

public class SimpleValidationResult : IValidationResult
{
  internal SimpleValidationResult(ResultType resultType, string label, string description)
  {
    ResultType = resultType;
    Label = label;
    Description = description;
  }

  public ValidationType Type => ValidationType.Simple;

  public string Description { get; }

  public ResultType ResultType { get; }
  public string Label { get; }
}