using NUnit.Framework;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
	public class ValidationFailureFactoryScenarioContext
	{
		private IValidationFailure? _currentValidationFailure;

		public void AssertCurrentValidationFailureIsValidationType(ValidationType validationType)
		{
			Assert.AreEqual(validationType, _currentValidationFailure?.GetValidationType());
		}

		public void AssertDeveloperDescriptionContains(string p0)
		{
			StringAssert.Contains(p0, _currentValidationFailure?.GetDescription());
		}

		public void SetCurrentValidationFailure(IValidationFailure validationFailure)
		{
			_currentValidationFailure = validationFailure;
		}
	}
}