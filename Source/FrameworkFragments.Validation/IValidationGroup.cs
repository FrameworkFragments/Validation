using System.Collections.Generic;

namespace FrameworkFragments.Validation;

public interface IValidationGroup : IReadOnlyCollection<IValidationResult>
{
  public bool HasFailures { get; }
}