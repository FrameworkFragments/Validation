using FrameworkFragments.Validation.Result;
using FrameworkFragments.Validation.Results;

namespace FrameworkFragments.Validation.Test.ValidationResultFactory;

public class Context
{
  internal ValidationResults.Builder? ValidationResultsBuilder { get; set; }

  public IValidationResults? ValidationResults { get; set; }
  public IValidationResult? CurrentValidationResult { get; set; }
}