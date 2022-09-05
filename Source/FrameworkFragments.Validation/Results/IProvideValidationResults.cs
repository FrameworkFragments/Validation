namespace FrameworkFragments.Validation.Results;

public interface IProvideValidationResults
{
  IValidationResults? ValidationResults { get; }
  bool HasValidationResults { get; }
}