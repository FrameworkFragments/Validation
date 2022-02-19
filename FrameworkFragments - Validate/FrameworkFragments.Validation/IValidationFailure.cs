namespace FrameworkFragments.Validation
{
    public interface IValidationFailure
    {
	    public ValidationType GetValidationType();
	    public string GetDescription();
    }
}
