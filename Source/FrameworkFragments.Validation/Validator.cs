using System.Collections.Generic;
using System.Collections.ObjectModel;
using FrameworkFragments.Validation.Result;
using FrameworkFragments.Validation.Results;

namespace FrameworkFragments.Validation;

public class Validator
{
  public delegate IEnumerable<IValidationResult> ValidationDelegate();

  private readonly List<ValidationDelegate> _validationDelegates = new();
  private bool _keepFailingValidationResults;
  private bool _keepPassingValidationResults;

  public Validator()
    : this(false, true)
  {
  }

  public Validator(bool keepPassingValidationResults, bool keepFailingValidationResults)
  {
    _keepPassingValidationResults = keepPassingValidationResults;
    _keepFailingValidationResults = keepFailingValidationResults;
  }

  public Validator Add(ValidationDelegate validationDelegate)
  {
    _validationDelegates.Add(validationDelegate);
    return this;
  }

  public Validator KeepPassingValidationResults()
  {
    _keepPassingValidationResults = true;
    return this;
  }

  public Validator SkipPassingValidationResults()
  {
    _keepPassingValidationResults = false;
    return this;
  }

  public Validator KeepFailingValidationResults()
  {
    _keepFailingValidationResults = true;
    return this;
  }

  public Validator SkipFailingValidationResults()
  {
    _keepFailingValidationResults = false;
    return this;
  }

  public IValidationResults Validate()
  {
    var list = new List<IValidationResult>(_validationDelegates.Count);
    var failureCount = 0; 
    var passCount = 0;
    foreach (var createValidationResultDelegate in _validationDelegates)
    {
      var validationResults = createValidationResultDelegate();
      foreach (var validationResult in validationResults)
      {
        if (validationResult.IsFailed)
        {
          failureCount++;
          if (_keepFailingValidationResults) list.Add(validationResult);
          continue;
        }

        if (validationResult.IsPassed)
        {
          passCount++;
          if (_keepPassingValidationResults)
            list.Add(validationResult);
        }
      }
    }

    return new ValidationResults(new ReadOnlyCollection<IValidationResult>(list), passCount,
      failureCount);
  }
}