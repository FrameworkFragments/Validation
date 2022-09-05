using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkFragments.Validation.Result;

namespace FrameworkFragments.Validation.Results;

public class ValidationResults : IValidationResults
{
  private readonly ReadOnlyCollection<IValidationResult> _validationResults;

  internal ValidationResults(ReadOnlyCollection<IValidationResult> validationResults)
  {
    _validationResults = validationResults;
    FailureCount = _validationResults.Select(a => ValidationResultType.Pass != a.ResultType).Count();
  }

  protected internal ValidationResults(
    ReadOnlyCollection<IValidationResult> validationResults,
    int passCount,
    int failureCount
  )
  {
    _validationResults = validationResults;
    PassCount = passCount;
    FailureCount = failureCount;
  }

  public bool HasFailures => FailureCount > 0;
  public int PassCount { get; }
  public int FailureCount { get; }

  public IEnumerator<IValidationResult> GetEnumerator()
  {
    return _validationResults.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public int Count => _validationResults.Count;

  public class Builder
  {
    public delegate IValidationResult CreateValidationResultDelegate();

    private readonly List<CreateValidationResultDelegate> _createValidationResultDelegates = new();

    public Builder Add(CreateValidationResultDelegate createValidationResultDelegate)
    {
      _createValidationResultDelegates.Add(createValidationResultDelegate);
      return this;
    }

    public Builder Add(ValidationResultType validationResultType, string label, string description)
    {
      _createValidationResultDelegates.Add(() => new ValidationResult(validationResultType, label, description));
      return this;
    }

    public Builder Add(IValidationResult validationResult)
    {
      _createValidationResultDelegates.Add(() => validationResult);
      return this;
    }

    public IValidationResults Build()
    {
      var list = new List<IValidationResult>(_createValidationResultDelegates.Count);
      var failureCount = 0;
      foreach (var createValidationResultDelegate in _createValidationResultDelegates)
      {
        var validationResult = createValidationResultDelegate();
        list.Add(validationResult);
        if (validationResult.IsPassed) continue;

        failureCount++;
      }

      return new ValidationResults(new ReadOnlyCollection<IValidationResult>(list), list.Count - failureCount,
        failureCount);
    }
  }
}