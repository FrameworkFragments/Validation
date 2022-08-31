namespace FrameworkFragments.Validation.Test.ValidationResultFactory;

public class Context
{
  private Validation.ValidationGroupBuilder? _validationGroupBuilder;
  internal bool HasValidationResultBuilder => null != _validationGroupBuilder;

  internal Validation.ValidationGroupBuilder ValidationGroupBuilder
  {
    get => _validationGroupBuilder!;
    set => _validationGroupBuilder = value;
  }

  private List<IValidationResult>? _validationResults;

  public IList<IValidationResult> ValidationResults
  {
    get { return _validationResults ??= new List<IValidationResult>(); }
  }

  public IValidationResult CurrentValidationResult
  {
    get => ValidationResults.Last();
    set => ValidationResults.Add(value);
  }
}