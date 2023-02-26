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
        #region Private Fields
        internal ManualLogSource _logSource;
        internal bool _enabled = false;
        internal bool _debugToConsole = false;
        internal static bool _specialLogFile = false;
        internal static StreamWriter _writer;
        #endregion

        #region Properties
        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                if (_logSource != null)
                {
                    _enabled = value;
                }
                else
                {
                    _enabled = false;
                }
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
                _logSource = value;
            }
        }
        #endregion

        #region Constructors
        public Logg()
        {
        }

        public Logg(ManualLogSource logSource)
        {
            LogSource = logSource;
        }
        #endregion

        #region Public Methods
        public void SetLogSource(ManualLogSource logSource)
        {
            _logSource = logSource;
        }

        public void Info(object data, bool withCaller = false)
        {
            if (_enabled)
            {
                string logMessage;

                if (withCaller)
                {
                    // Get call stack
                    var stackTrace = new StackTrace();

                    // Get calling method name
                    var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                    logMessage = $"Called by:[{calllingMethod}] {data}";
                }
                else
                {
                    logMessage = $"{data}";
                }

                _logSource.LogInfo($"{logMessage}");
            }
        }

        public void Debug(object data, bool withCaller = false)
        {
            if (_enabled)
            {
                string logMessage;

                if (withCaller)
                {
                    // Get call stack
                    var stackTrace = new StackTrace();

                    // Get calling method name
                    var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                    logMessage = $"Called by:[{calllingMethod}] {data}";
                }
                else
                {
                    logMessage = $"{data}";
                }

                if (_debugToConsole)
                {
                    _logSource.LogInfo($"{logMessage}");
                }
                else
                {
                    _logSource.LogDebug($"{logMessage}");
                }
            }
        }

        public void Error(object data, bool withCaller = false)
        {
            string logMessage;

            if (withCaller)
            {
                // Get call stack
                var stackTrace = new StackTrace();

                // Get calling method name
                var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                logMessage = $"Called by:[{calllingMethod}] {data}";
            }
            else
            {
                logMessage = $"{data}";
            }
            if (_enabled)
            {
                _logSource.LogError($"{logMessage}");
            }
        }

        public void Fatal(object data, bool withCaller = false)
        {
            string logMessage;

            if (withCaller)
            {
                // Get call stack
                var stackTrace = new StackTrace();

                // Get calling method name
                var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                logMessage = $"Called by:[{calllingMethod}] {data}";
            }
            else
            {
                logMessage = $"{data}";
            }
            if (_enabled)
            {
                _logSource.LogFatal($"{logMessage}");
            }
        }

        public void Message(object data, bool withCaller = false)
        {
            if (_enabled)
            {
                string logMessage;

                if (withCaller)
                {
                    // Get call stack
                    var stackTrace = new StackTrace();

                    // Get calling method name
                    var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                    logMessage = $"Called by:[{calllingMethod}] {data}";
                }
                else
                {
                    logMessage = $"{data}";
                }
                _logSource.LogMessage($"{logMessage}");
            }
        }

        public void Warning(object data, bool withCaller = false)
        {
            if (_enabled)
            {
                string logMessage;

                if (withCaller)
                {
                    // Get call stack
                    var stackTrace = new StackTrace();

                    // Get calling method name
                    var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                    logMessage = $"Called by:[{calllingMethod}] {data}";
                }
                else
                {
                    logMessage = $"{data}";
                }

                _logSource.LogWarning($"{logMessage}");
            }
        }

        /// <summary>
        /// For logs that should not depend on the logs been enabled
        /// </summary>
        /// <param name="level"></param>
        /// <param name="data"></param>
        public void Level(LogLevel level, object data, bool withCaller = false)
        {
            string logMessage;

            if (withCaller)
            {
                // Get call stack
                var stackTrace = new StackTrace();

                // Get calling method name
                var calllingMethod = stackTrace.GetFrame(1).GetMethod().Name;

                logMessage = $"Called by:[{calllingMethod}] {data}";
            }
            else
            {
                logMessage = $"{data}";
            }

            _logSource.Log(level, logMessage);
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
            _writer?.Close();
        }
        #endregion

        #region Private Methods
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
        #endregion
    }
}
