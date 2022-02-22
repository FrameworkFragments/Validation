using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class RequiredReferenceStep
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public RequiredReferenceStep(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
		[When(@"A RequiredReference Validation failure is created for ""(.*)""")]
	    public void WhenARequiredReferenceValidationFailureIsCreatedFor(string p0)
	    {
		    _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
			    ValidationFailureFactory.Singleton.RequiredReference(new List<string>() { p0 }));
		}

    }
}
