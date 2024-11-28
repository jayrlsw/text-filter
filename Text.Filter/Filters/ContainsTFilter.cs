namespace Text.Filter.Filters
{
    public class ContainsTFilter : IFilter
    {
        public bool Filter(string text)
        {
            return !text.Contains('t', StringComparison.OrdinalIgnoreCase);
        }
    }
}
