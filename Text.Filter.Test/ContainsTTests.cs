using Text.Filter.Filters;

namespace Text.Filter.Test
{
    public class ContainsTTests
    {
        private readonly ContainsTFilter _filter;

        public ContainsTTests()
        {
            _filter = new ContainsTFilter();
        }

        [Theory]
        [InlineData("Crepe")]
        [InlineData("movie")]
        [InlineData("WOLF")]
        public void Should_Allow_Valid(string text)
        {
            Assert.NotEmpty(_filter.Apply(text));
        }

        [Theory]
        [InlineData("What")]
        [InlineData("Meet")]
        [InlineData("mountain")]
        public void Should_Reject_Invalid(string text)
        {
            Assert.Empty(_filter.Apply(text));
        }
    }
}
