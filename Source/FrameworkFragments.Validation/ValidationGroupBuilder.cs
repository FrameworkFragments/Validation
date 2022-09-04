using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FrameworkFragments.Validation;

public class ValidationGroupBuilder
{
  private readonly List<IValidationResult> _validationResults = new List<IValidationResult>();
  public ValidationGroupBuilder Add(IValidationResult validationResult)
  {
    _validationResults.Add(validationResult);
    return this;
  }
  public IValidationGroup Build()
  {
    return new ValidationGroup(
      new ReadOnlyCollection<IValidationResult>(_validationResults)
    );
  }
}