using System.Collections.Generic;

namespace FrameworkFragments.Validation;

public interface IValidationResults : IReadOnlyCollection<IValidationResult>
{
  public bool HasFailures { get; }
  public int PassCount { get; }
  public int FailureCount { get; }
}