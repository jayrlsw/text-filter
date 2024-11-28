namespace Text.Filter.Filters
{
    public class VowelInMiddleFilter : IFilter
    {
        private static readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];

        public bool Filter(string text)
        {
            if (text.Length % 2 == 0)
            {
                return !Array.Exists(vowels, e => e == char.ToLower(text[text.Length / 2])) &&
                       !Array.Exists(vowels, e => e == char.ToLower(text[(text.Length - 1) / 2]));
            }
            else
            {
                return !Array.Exists(vowels, e => e == char.ToLower(text[(text.Length - 1) / 2]));
            }
        }
    }
}
