using System;

namespace MagicTheme.Utils.Loggers
{
    public class ConsoleLogger:AbstractLogger
    {
        internal override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
