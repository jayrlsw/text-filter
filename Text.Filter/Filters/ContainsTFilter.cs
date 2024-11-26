namespace Text.Filter.Filters
{
    public class ContainsTFilter : IFilter
    {
        public string Apply(string text)
        {
            return text.Contains('t', StringComparison.OrdinalIgnoreCase) ? string.Empty : text;
        }
    }
}
