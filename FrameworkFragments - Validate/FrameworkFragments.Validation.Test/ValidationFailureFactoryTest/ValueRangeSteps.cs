using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class ValueRangeSteps
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public ValueRangeSteps(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
        [When(@"A ValueRange Validation failure is created for ""(.*)""")]
        public void WhenAValueRangeValidationFailureIsCreatedFor(string p0)
        {
            _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
	            ValidationFailureFactory.Singleton.ValueRange(new List<string>() { p0 }));
        }
    }
}
