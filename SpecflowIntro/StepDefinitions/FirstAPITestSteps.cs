using SpecflowIntro.DataClass;
using System;
using TechTalk.SpecFlow;

namespace SpecflowIntro.StepDefinitions
{
    [Binding]
    public class FirstAPITestSteps
    {
        [Given(@"I query the API")]
        public void GivenIQueryTheAPI()
        {
            ScenarioContext.Current.Pending();
        }
        private readonly AddCart acart = new AddCart();

        [Then(@"I add (.*) to cart")]
            public void ThenIAddSpoonToCart(string item)
            {
            acart.AddItemToCart(item);
                
             }
       
    }
}