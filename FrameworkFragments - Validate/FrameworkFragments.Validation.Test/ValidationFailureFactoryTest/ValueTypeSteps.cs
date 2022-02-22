using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class ValueTypeSteps
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public ValueTypeSteps(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
        [When(@"A ValueType Validation failure is created for ""(.*)""")]
        public void WhenAValueTypeValidationFailureIsCreatedFor(string p0)
        {
	        _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
		        ValidationFailureFactory.Singleton.ValueType(new List<string>() { p0 }));
        }
    }
}
