using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Text.Filter.Filters;
using Text.Filter.TextProcessor;

namespace Text.Filter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService<Worker>();
            builder.Services.AddTransient<ITextProcessorService, TextProcessorService>();
            builder.Services.AddTransient<IFilter, ContainsTFilter>();
            builder.Services.AddTransient<IFilter, LengthLessThan3Filter>();
            builder.Services.AddTransient<IFilter, VowelInMiddleFilter>();

            using var host = builder.Build();
            host.Run();
        }
    }
}