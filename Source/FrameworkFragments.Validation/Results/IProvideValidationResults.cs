namespace FrameworkFragments.Validation;

public interface IProvideValidationResults
{
  IValidationResults? ValidationResults { get; }
  bool HasValidationResults { get; }
}