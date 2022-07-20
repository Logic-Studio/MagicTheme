﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagicTheme.Utils.Loggers
{
    public class FileLogger : AbstractLogger
    {
        private static readonly Dictionary<string, ReaderWriterLockSlim> _allLocks
            = new Dictionary<string, ReaderWriterLockSlim>();

        public string Path { get; set; }

        public FileLogger(string path)
        {
            Path = path;

            if (!_allLocks.ContainsKey(path))
            {
                _allLocks.Add(path, new ReaderWriterLockSlim());
            }
        }

        internal override void WriteMessage(string message)
        {
            ReaderWriterLockSlim currentLock = _allLocks[Path];

            try
            {
                currentLock.EnterWriteLock();

                using (StreamWriter writer = File.AppendText(Path))
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing log to file: {1}", ex.Message);
            }
            finally
            {
                currentLock.ExitWriteLock();
            }
        }
    }
}
