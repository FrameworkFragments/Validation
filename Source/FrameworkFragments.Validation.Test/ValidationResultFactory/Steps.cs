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
    _context.ValidationGroupBuilder = new Validation.ValidationGroupBuilder();
  }

  [Given(@"the following validation is added")]
  [Given(@"the following validations are added")]
  public void GivenTheFollowingValidationIsAdded(Table table)
  {
    foreach (var row in table.Rows)
    {
      var resultTypeString = table.Rows[0]["ResultType"];
      if (!Enum.TryParse(resultTypeString, out ResultType validationResultType))
      {
        Assert.Fail($"Unable to parse specification parameter \"ResultType\" containing value \"{resultTypeString}\"");
        return;
      }

      _context.CurrentValidationResult = Validation.ValidationResultFactory.Singleton.SimpleValidation(
        validationResultType,
        table.Rows[0]["Label"],
        table.Rows[0]["Description"]
      );
    }
  }

  [Then(@"the current validation result type is Pass")]
  public void ThenTheCurrentValidationResultTypeIsPass()
  {
    Assert.AreNotEqual(ResultType.Pass, _context.CurrentValidationResult.Type);
  }

  [Then(@"the current validation result type is Fail")]
  public void ThenTheCurrentValidationResultTypeIsFail()
  {
    Assert.AreNotEqual(ResultType.Fail, _context.CurrentValidationResult.Type);
  }

  [Then(@"the current validation label is ""(.*)""")]
  public void ThenTheCurrentValidationLabelIs(string label)
  {
    Assert.AreEqual(label, _context.CurrentValidationResult.Label);
  }

  [Then(@"the current validation description is null")]
  public void ThenTheCurrentValidationDescriptionIsNull()
  {
    Assert.IsEmpty(_context.CurrentValidationResult.Description);
  }

  [Then(@"the current validation description is ""(.*)""")]
  public void ThenTheCurrentValidationDescriptionIs(string description)
  {
    Assert.AreEqual(description, _context.CurrentValidationResult.Description);
  }
}