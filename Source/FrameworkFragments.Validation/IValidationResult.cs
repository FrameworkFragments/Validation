namespace FrameworkFragments.Validation;

public interface IValidationResult
{
  public ValidationType Type { get; }
  public string Description { get; }
  public string Label { get; }
  public VaidationResultType ResultType { get; }
}