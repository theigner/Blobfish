namespace Blobfish.UnitTests
{
    using FluentAssertions;
    
    using Xunit;

    public class AnimlDocumentValidatorTests
    {
        [Fact]
        public void AnimlDocumentValidatedCorrectly()
        {
            //// Create a new minimal AnIML document and add one sample
            //// Using "1" as Id should result in a validation error b/c this name is not compliant with the 
            //// AnIML standard as xsd:ID does not allow numbers as first character

            AnimlDocument animlDoc = new AnimlDocument() { SampleSet = new SampleSet() };
            animlDoc.SampleSet.Samples.Add(new Sample("TestSample", "1st sample") { Id = "1"});

            bool validationOutcome;

            AnimlDocumentValidator validatorFail = AnimlDocumentValidator.CreateValidatorForAnimlDocument(animlDoc);
            validationOutcome = validatorFail.Validate();

            validationOutcome.Should().BeFalse();
            validatorFail.ValidationMessages.Should().HaveCount(1);

            //// Change the ID to a valid value and perform the validation once again.
            animlDoc.SampleSet.Samples[0].Id = "ID-1";

            AnimlDocumentValidator validatorSucceed = AnimlDocumentValidator.CreateValidatorForAnimlDocument(animlDoc);
            validationOutcome = validatorSucceed.Validate();

            validationOutcome.Should().BeTrue();
            validatorSucceed.ValidationMessages.Should().BeEmpty();
        }
    }
}
