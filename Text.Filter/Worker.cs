using Microsoft.Extensions.Hosting;
using Text.Filter.TextProcessor;

namespace Text.Filter
{
    public class Worker : BackgroundService
    {
        private readonly ITextProcessorService _textProcessorService;

        public Worker(ITextProcessorService textProcessorService) {
            _textProcessorService = textProcessorService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var rawResult = _textProcessorService.ProcessTextRaw("input.txt");
            Console.WriteLine(rawResult);

            _textProcessorService.Clear();
            var listResult = _textProcessorService.ProcessTextEnumerable("input.txt");
            foreach (var result in listResult)
            { 
                Console.WriteLine(result);
            }

            return Task.CompletedTask;
        }
    }
}
