namespace FrameworkFragments.Validation;

public class SimpleValidationResult : IValidationResult
{
  internal SimpleValidationResult(VaidationResultType vaidationResultType, string label, string description)
  {
    ResultType = vaidationResultType;
    Label = label;
    Description = description;
  }

  public ValidationType Type => ValidationType.Simple;

  public string Description { get; }

  public VaidationResultType ResultType { get; }
  public string Label { get; }
}