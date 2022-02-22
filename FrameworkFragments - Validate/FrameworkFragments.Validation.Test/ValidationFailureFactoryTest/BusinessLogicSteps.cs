using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FrameworkFragments.Validation.Test.ValidationFailureFactoryTest
{
    [Binding]
    public class BusinessLogicSteps
    {
	    private readonly ValidationFailureFactoryScenarioContext _validationFailureFactoryScenarioContext;

	    public BusinessLogicSteps(ValidationFailureFactoryScenarioContext validationFailureFactoryScenarioContext)
	    {
		    _validationFailureFactoryScenarioContext = validationFailureFactoryScenarioContext;
	    }
        [When(@"A BusinessLogic Validation failure is created for ""(.*)""")]
        public void WhenABusinessLogicValidationFailureIsCreatedFor(string p0)
        {
            _validationFailureFactoryScenarioContext.SetCurrentValidationFailure(
	            ValidationFailureFactory.Singleton.BusinessLogic(new List<string>() { p0 }));
        }
    }
}
