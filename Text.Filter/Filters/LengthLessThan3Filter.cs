namespace Text.Filter.Filters
{
    public class LengthLessThan3Filter : IFilter
    {
        public bool Filter(string text)
        {
            return !(text.Length < 3);
        }
    }
}
