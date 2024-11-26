using Text.Filter.Filters;

namespace Text.Filter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");

            IFilter[] filters = { new VowelInMiddleFilter(), new LengthLessThan3Filter(), new ContainsTFilter() };

            var result = string.Empty;
            string word = string.Empty;
            do {
                char c = (char)reader.Read();
                if (char.IsLetter(c)) {
                    word += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        foreach (var filter in filters)
                            word = filter.Apply(word);
                        if (!string.IsNullOrEmpty(word))
                        {
                            result += word;
                        }
                    }
                    result += c;
                    word = string.Empty;
                }
            } while (!reader.EndOfStream);

            Console.WriteLine(result);
        }
    }
}