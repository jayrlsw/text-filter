using System.Text;
using Text.Filter.Filters;

namespace Text.Filter.TextProcessor
{
    public class TextProcessorService : ITextProcessorService
    {
        private readonly char[] _allowedSymbols = ['\'', '-'];

        private readonly IEnumerable<IFilter> _filters;

        private readonly List<string> _listResult = [];
        private readonly StringBuilder _rawResult = new();
        private char? _lastChar = null;

        public TextProcessorService(IEnumerable<IFilter> filters) {
            _filters = filters;
        }

        public IEnumerable<string> ProcessTextEnumerable(string fileName)
        {
            ProcessText(fileName);
            return _listResult;
        }

        public string ProcessTextRaw(string fileName)
        {
            ProcessText(fileName);
            return _rawResult.ToString();
        }

        public void Clear()
        {
            _rawResult.Clear();
            _listResult.Clear();
        }

        private void ProcessText(string fileName)
        {
            using var reader = new StreamReader(fileName);

            var resultBuilder = new StringBuilder();
            var wordBuilder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                char c = (char)reader.Read();
                if (IsSymbolAllowed(c))
                {
                    wordBuilder.Append(c);
                }
                else
                {
                    if (wordBuilder.Length > 0)
                    {
                        bool filterSuccess = true;
                        string word = wordBuilder.ToString();
                        foreach (var filter in _filters)
                        {
                            if (!filter.Filter(word))
                            {
                                filterSuccess = false;
                                break;
                            }
                        }
                        if (filterSuccess)
                        {
                            _listResult.Add(word);
                            _rawResult.Append(wordBuilder);
                        }
                    }
                    _rawResult.Append(c);
                    wordBuilder.Clear();
                }
                _lastChar = c;
            }
        }

        private bool IsSymbolAllowed(char c)
        {
            if (char.IsLetter(c))
                return true;

            return _lastChar != null && char.IsLetter((char)_lastChar) && Array.Exists(_allowedSymbols, s => s == c);
        }
    }
}
