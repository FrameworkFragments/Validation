//using Smelter.Common.Validation;

using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class UniquenessSteps
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public UniquenessSteps(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
	    
	    [When(@"A Uniqueness Validation failure is created for ""(.*)""")]
	    public void WhenAUniquenessValidationFailureIsCreatedFor(string p0)
	    {
		    _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
			    ValidationFailureFactory.Singleton.Uniqueness(new List<string>(){p0}));
	    }

	    [Then(@"The current validation failure has validation type ""(.*)""")]
		public void ThenTheCurrentValidationFailureHasValidationType(ValidationType p0)
		{
			_validationFailureFactoryScenarioContext.AssertCurrentValidationFailureIsValidationType(p0);
		}

		[Then(@"The current validation failure developer description contains ""(.*)""")]
		public void ThenTheCurrentValidationFailureDeveloperDescriptionContains(string p0)
		{
			_validationFailureFactoryScenarioContext.AssertDeveloperDescriptionContains(p0);
		}


	}
}
