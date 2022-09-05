using System.Collections.Generic;
using FrameworkFragments.Validation.Result;

namespace FrameworkFragments.Validation.Results;

public interface IValidationResults : IReadOnlyCollection<IValidationResult>
{
  public bool HasFailures { get; }
  public int PassCount { get; }
  public int FailureCount { get; }
}