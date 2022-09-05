namespace FrameworkFragments.Validation;

public interface IValidationResult
{
  public string Description { get; }
  public string Label { get; }
  public ValidationResultType ResultType { get; }

  public bool IsPassed { get; }
  public bool IsFailed { get; }
}