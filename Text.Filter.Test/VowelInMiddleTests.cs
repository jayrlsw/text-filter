using Text.Filter.Filters;

namespace Text.Filter.Test
{
    public class VowelInMiddleTests
    {
        private readonly VowelInMiddleFilter _filter;

        public VowelInMiddleTests()
        {
            _filter = new VowelInMiddleFilter();
        }

        [Theory]
        [InlineData("Tenner")]
        [InlineData("Fry")]
        [InlineData("Curry")]
        [InlineData("rhythm")]
        public void Should_Allow_Valid(string text)
        {
            Assert.NotEmpty(_filter.Apply(text));
        }

        [Theory]
        [InlineData("hey")]
        [InlineData("HEY")]
        [InlineData("good")]
        [InlineData("Plan")]
        [InlineData("Will")]
        public void Should_Reject_Invalid(string text)
        {
            Assert.Empty(_filter.Apply(text));
        }
    }
}
