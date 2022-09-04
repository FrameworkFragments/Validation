using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FrameworkFragments.Validation;

public class ValidationGroup : IValidationGroup
{
  private readonly ReadOnlyCollection<IValidationResult> _validationResults;
  public bool HasFailures { get; } 
  public ValidationGroup(ReadOnlyCollection<IValidationResult> validationResults)
  {
    _validationResults = validationResults;
    HasFailures = _validationResults.Any(a => VaidationResultType.Pass != a.ResultType);
  }
  public IEnumerator<IValidationResult> GetEnumerator()
  {
    return _validationResults.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public int Count => _validationResults.Count;
}