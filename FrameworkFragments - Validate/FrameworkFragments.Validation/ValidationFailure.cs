namespace FrameworkFragments.Validation
{
    public class ValidationFailure: IValidationFailure
    {
	    private readonly ValidationType _validationType;
	    private readonly string _validationId;
	    private readonly string _developerExplanation;

        internal ValidationFailure(
            ValidationType validationType,
            string validationId,
            string developerExplanation
        )
        {
            _validationType = validationType;
            _validationId = validationId;
            _developerExplanation = developerExplanation;
        }

        public ValidationType GetValidationType()
        {
	        return _validationType;
        }
        public string GetDescription()
        {
	        return _developerExplanation;
        }

    }
}
