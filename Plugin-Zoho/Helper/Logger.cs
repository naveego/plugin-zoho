using System;
using System.IO;
using System.Threading;

namespace Plugin_Zoho.Helper
{
    public static class Logger
    {
        public enum LogLevel
        {
            Verbose,
            Debug,
            Info,
            Error,
            Off
        }
        
        private static LogLevel _level = LogLevel.Info;
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        
        /// <summary>
        /// Writes a log message with time stamp to a file
        /// </summary>
        /// <param name="message"></param>
        private static void Log(string message)
        {
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(@"plugin.txt"))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Logging method for Verbose messages
        /// </summary>
        /// <param name="message"></param>
        public static void Verbose(string message)
        {
            if (_level > LogLevel.Verbose)
            {
                return;
            }
            
            Log(message);
        }
        
        /// <summary>
        /// Logging method for Debug messages
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            if (_level > LogLevel.Debug)
            {
                return;
            }
            
            Log(message);
        }
        /// <summary>
        /// Logging method for Info messages
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if (_level > LogLevel.Info)
            {
                return;
            }
            
            Log(message);
        }
        
        /// <summary>
        /// Logging method for Error messages
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            if (_level > LogLevel.Error)
            {
                return;
            }
            
            Log(message);
        }

        /// <summary>
        /// Sets the log level 
        /// </summary>
        /// <param name="level"></param>
        public static void SetLogLevel(LogLevel level)
        {
            _level = level;
        }
    }
}