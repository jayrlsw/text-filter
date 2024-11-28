using Text.Filter.Filters;

namespace Text.Filter.Test
{
    public class LengthLessThan3Tests
    {
        private readonly LengthLessThan3Filter _filter;

        public LengthLessThan3Tests()
        {
            _filter = new LengthLessThan3Filter();
        }

        [Theory]
        [InlineData("Tenner")]
        [InlineData("Fry")]
        [InlineData("Curry")]
        public void Should_Allow_Valid(string text)
        {
            Assert.True(_filter.Filter(text));
        }

        [Theory]
        [InlineData("do")]
        [InlineData("HI")]
        [InlineData("Oh")]
        [InlineData("a")]
        [InlineData("")]
        public void Should_Reject_Invalid(string text)
        {
            Assert.False(_filter.Filter(text));
        }
    }
}
