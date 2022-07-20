using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using System.Diagnostics;

namespace MagicTheme.Utils.Loggers
{
    public class AppLogger
    {
        public static ILogger GetLoggerForCurrentClass()
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string logsPath = localFolder.Path + "\\Logs\\";
            if (Directory.Exists(logsPath) == false)
            {
                Directory.CreateDirectory(logsPath);
            }
            ILogger logger = new MultiLogger(new FileLogger($"{logsPath}Application.log") { MinimumLevel = LogLevel.Info },
                                                     new FileLogger($"{logsPath}Error.log") { MinimumLevel = LogLevel.Info },
                                                     new FileLogger($"{logsPath}Update.log"){MinimumLevel =LogLevel.Info},
                                                     new ConsoleLogger() { MaximumLevel = LogLevel.Error }
                                                     );
            StackTrace trace = new StackTrace();

            if (trace.FrameCount > 1)
            {
                logger.ClassTag = trace.GetFrame(1).GetMethod().DeclaringType.Name;
            }

            return logger;
        }
    }
}
