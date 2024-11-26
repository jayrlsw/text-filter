namespace Text.Filter.Filters
{
    public class LengthLessThan3Filter : IFilter
    {
        public string Apply(string text)
        {
            return text.Length < 3 ? string.Empty : text;
        }
    }
}
