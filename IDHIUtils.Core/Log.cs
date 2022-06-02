//
// Log class with runtime enable/disable display of logs
//

using System;
using System.Diagnostics;
using System.IO;

using BepInEx.Logging;


namespace IDHIUtils
{
    /// <summary>
    /// Show logs when enabled
    /// </summary>

    public class Logg
    {
        internal ManualLogSource _logSource;
        internal bool _enabled = false;
        internal bool _debugToConsole = false;
        internal static bool _specialLogFile = false;
        internal static StreamWriter _writer;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
            }
        }

        public static bool SpecialLogFile
        {
            get
            {
                return _specialLogFile;
            }
            set
            {
                if (value)
                {
                    _specialLogFile = true;
                    SetupLogFile();
                }
            }
        }

        public bool DebugToConsole
        {
            get
            {
                return _debugToConsole;
            }
            set
            {
                _debugToConsole = value;
            }
        }

        public ManualLogSource LogSource
        {
            get
            {
                return _logSource;
            }
            set
            {
                if (_logSource == null)
                {
                    _logSource = value;
                }
            }
        }

        public void SetLogSource(ManualLogSource logSource)
        {
            if (_logSource == null)
            {
                _logSource = logSource;
            }
        }

        public void Info(object data)
        {
            if (_enabled)
            {
                _logSource.LogInfo(data);
            }
        }

        public void Debug(object data)
        {
            if (_enabled)
            {
                if (_debugToConsole)
                {
                    _logSource.LogInfo(data);
                }
                else
                {
                    _logSource.LogDebug(data);
                }
            }
        }

        public void Error(object data)
        {
            if (_enabled)
            {
                _logSource.LogError(data);
            }
        }

        public void Fatal(object data)
        {
            if (_enabled)
            {
                _logSource.LogFatal(data);
            }
        }

        public void Message(object data)
        {
            if (_enabled)
            {
                _logSource.LogMessage(data);
            }
        }

        public void Warning(object data)
        {
            if (_enabled)
            {
                _logSource.LogWarning(data);
            }
        }

        /// <summary>
        /// For logs that should not depend on the logs been enabled
        /// </summary>
        /// <param name="level"></param>
        /// <param name="data"></param>
        public void Level(LogLevel level, object data)
        {
            _logSource.Log(level, data);
        }

        public static void Special(object data)
        {
            if (_specialLogFile)
            {
                // Get call stack
                var stackTrace = new StackTrace();

                // Get calling method name
                var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                if (_writer.BaseStream != null)
                {
                    _writer.WriteLine($"Called by:[{calllingMethod}] {data}");
                    _writer.Flush();
                }
            }
        }

        public static void Close()
        {
            if (_writer != null)
            {
                _writer.Close();
            }
        }

        private static void SetupLogFile()
        {
            if (_writer == null)
            {
                var logFilePath = Path.Combine(UserData.Path, "Logs");
                var fileName = $"{logFilePath}/Special.log";
                var logFileInfo = new FileInfo(fileName);


                logFileInfo.Directory.Create();
                _writer = new StreamWriter(fileName);
                _specialLogFile = true;
            }
        }
    }
}
