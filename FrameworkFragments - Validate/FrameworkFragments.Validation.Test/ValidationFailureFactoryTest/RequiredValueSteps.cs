using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class RequiredValueSteps
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public RequiredValueSteps(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
        [When(@"A RequiredValue Validation failure is created for ""(.*)""")]
        public void WhenARequiredValueValidationFailureIsCreatedFor(string p0)
        {
	        _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
		        ValidationFailureFactory.Singleton.RequiredValue(new List<string>() { p0 }));
        }
    }
}
