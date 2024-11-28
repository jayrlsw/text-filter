namespace Text.Filter.TextProcessor
{
    public interface ITextProcessorService
    {
        void Clear();
        string ProcessTextRaw(string fileName);
        IEnumerable<string> ProcessTextEnumerable(string fileName);
    }
}
