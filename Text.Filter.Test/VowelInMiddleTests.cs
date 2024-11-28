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
        [InlineData("wasn't")]
        public void Should_Allow_Valid(string text)
        {
            Assert.True(_filter.Filter(text));
        }

        [Theory]
        [InlineData("hey")]
        [InlineData("HEY")]
        [InlineData("good")]
        [InlineData("Plan")]
        [InlineData("Will")]
        [InlineData("James'")]
        public void Should_Reject_Invalid(string text)
        {
            Assert.False(_filter.Filter(text));
        }
    }
}
