using Microsoft.Extensions.Logging;

namespace ConsoleLogging_6._0
{
    public static class TestBench 
    {
        public static void RunTest(int repetitions = 1000)
        {
            TextWriter orig = Console.Out;
            ConsoleWriter writer = new ConsoleWriter(Console.Out);
            Console.SetOut(writer);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<object>();

            for (int i = 0; i < repetitions; i++)
            {
                logger.LogInformation("Message #{i}", i);
            }

            loggerFactory.Dispose();
            Console.SetOut(orig);

            bool flushedAll = writer.Content.Contains(string.Format("Message #{0}", repetitions - 1));
            Console.WriteLine("Flushed all messages: " + flushedAll);
        }
    }
}