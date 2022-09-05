using NUnit.Framework;

namespace FrameworkFragments.Validation.Test.ValidationResultFactory;

[Binding]
public class Steps
{
  private readonly Context _context;

  public Steps(Context context)
  {
    _context = context;
  }

  [Given(@"a ValidationResultBuilder")]
  public void GivenAValidationResultBuilder()
  {
    _context.ValidationResultsBuilder = new ValidationResults.Builder();
  }

  [Given(@"the following validation is added")]
  [Given(@"the following validations are added")]
  public void GivenTheFollowingValidationIsAdded(Table table)
  {
    foreach (var row in table.Rows)
    {
      var resultTypeString = table.Rows[0]["ResultType"];
      if (!Enum.TryParse(resultTypeString, out ValidationResultType validationResultType))
      {
        Assert.Fail($"Unable to parse specification parameter \"ResultType\" containing value \"{resultTypeString}\"");
        return;
      }

      _context.ValidationResultsBuilder!.Add(() =>
        Validation.ValidationResultFactory.Singleton.SimpleValidation(validationResultType, table.Rows[0]["Label"],
          table.Rows[0]["Description"]));
    }
  }

  [Then(@"the current validation result type is Pass")]
  public void ThenTheCurrentValidationResultTypeIsPass()
  {
    Assert.AreNotEqual(ValidationResultType.Pass, _context.CurrentValidationResult!.Type);
  }

  [Then(@"the current validation result type is Fail")]
  public void ThenTheCurrentValidationResultTypeIsFail()
  {
    Assert.AreNotEqual(ValidationResultType.Fail, _context.CurrentValidationResult!.Type);
  }

  [Then(@"the current validation label is ""(.*)""")]
  public void ThenTheCurrentValidationLabelIs(string label)
  {
    Assert.AreEqual(label, _context.CurrentValidationResult!.Label);
  }

  [Then(@"the current validation description is null")]
  public void ThenTheCurrentValidationDescriptionIsNull()
  {
    Assert.IsEmpty(_context.CurrentValidationResult!.Description);
  }

  [Then(@"the current validation description is ""(.*)""")]
  public void ThenTheCurrentValidationDescriptionIs(string description)
  {
    Assert.AreEqual(description, _context.CurrentValidationResult!.Description);
  }

  [When(@"the ValidationResults are Built")]
  public void WhenTheValidationResultsAreBuilt()
  {
    _context.ValidationResults = _context.ValidationResultsBuilder!.Build();
    _context.CurrentValidationResult = _context.ValidationResults.First();
  }

  [Then(@"the current ValidationResults has no errors")]
  public void ThenTheCurrentValidationResultsHasNoErrors()
  {
    Assert.NotNull(_context.ValidationResults);
    Assert.IsFalse(_context.ValidationResults!.HasFailures);
  }

  [Then(@"the current ValidationResults has (.*) error[s]{0,1}")]
  public void ThenTheCurrentValidationResultsHasError(int failureCount)
  {
    Assert.NotNull(_context.ValidationResults);
    Assert.AreEqual(failureCount, _context.ValidationResults!.FailureCount);
  }
}