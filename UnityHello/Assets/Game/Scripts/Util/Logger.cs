using UnityEngine;
using System.Collections;
using System;
using LuaInterface;
using System.Diagnostics;
using System.IO;

namespace KEngine
{
    public enum LogLevel
    {
        All = 0,
        Trace,
        Debug,
        Info, // Info, default
        Warning,
        Error,
        None,
    }
    public class Log
    {
        public delegate void LogCallback(string condition, string stackTrace, LogLevel type);
        public static LogLevel LogLevel = LogLevel.Info;

        private static event LogCallback LogCallbackEvent;
        private static bool _hasRegisterLogCallback = false;
        /// <summary>
        /// 第一次使用时注册，之所以不放到静态构造器，因为多线程问题
        /// </summary>
        /// <param name="callback"></param>
        public static void AddLogCallback(LogCallback callback)
        {
            if (!_hasRegisterLogCallback)
            {
                _hasRegisterLogCallback = true;
                Application.logMessageReceivedThreaded += GetUnityLogCallback(OnLogCallback);
            }
            LogCallbackEvent += callback;
        }

        public static void RemoveLogCallback(LogCallback callback)
        {
            if (!_hasRegisterLogCallback)
            {
                _hasRegisterLogCallback = true;
                Application.logMessageReceivedThreaded += GetUnityLogCallback(callback);
            }
            LogCallbackEvent -= callback;
        }

        static Application.LogCallback GetUnityLogCallback(LogCallback callback)
        {
            Application.LogCallback unityCallback = (c, s, type) =>
            {
                LogLevel logLevel;
                if (type == LogType.Error) logLevel = LogLevel.Error;
                else if (type == LogType.Warning) logLevel = LogLevel.Warning;
                else logLevel = LogLevel.Info;

                OnLogCallback(c, s, logLevel);
            };
            return unityCallback;
        }

        private static void OnLogCallback(string condition, string stacktrace, LogLevel type)
        {
            if (LogCallbackEvent != null)
            {
                lock (LogCallbackEvent)
                {
                    LogCallbackEvent(condition, stacktrace, type);
                }
            }
        }

        public static readonly bool IsUnityEditor = false;
        public static event Action<string> LogErrorEvent;

        static Log()
        {
            try
            {
                //IsDebugBuild = Debug.isDebugBuild;
                IsUnityEditor = Application.isEditor;
            }
            catch (Exception e)
            {
                Log.LogConsole_MultiThread("Log Static Constructor Failed!");
                Log.LogConsole_MultiThread(e.Message + " , " + e.StackTrace);
            }
        }

        /// <summary>
        /// 是否输出到日志文件,默认false，需要初始化手工设置
        /// </summary>
        private static bool _isLogFile = false;
        public static bool IsLogFile
        {
            get { return _isLogFile; }
            set
            {
                _isLogFile = value;
                if (_isLogFile)
                {
                    AddLogCallback(LogFileCallbackHandler);
                }
                else
                {
                    RemoveLogCallback(LogFileCallbackHandler);
                }
            }
        }

        public static void LogFileCallbackHandler(string condition, string stacktrace, LogLevel type)
        {
            try
            {
                if (type > LogLevel.Warning)
                    LogToFile(condition + "\n\n");
                else
                    LogToFile(condition + stacktrace + "\n\n");
            }
            catch (Exception e)
            {
                LogToFile(string.Format("LogFileError: {0}, {1}", condition, e.Message));
            }
        }

        // 这个使用系统的log，这个很特别，它可以再多线程里用，其它都不能再多线程内用！！！
        public static void LogConsole_MultiThread(string log, params object[] args)
        {
            DoLog(log, args, LogLevel.Info);
        }

        public static void Trace(string log, params object[] args)
        {
            DoLog(log, args, LogLevel.Trace);
        }

        public static void Debug(string log, params object[] args)
        {
            DoLog(log, args, LogLevel.Debug);
        }

        public static void Info(string log, params object[] args)
        {
            DoLog(log, args, LogLevel.Info);
        }

        public static void Logs(params object[] logs)
        {
            var sb = StringBuilderCache.Acquire();
            for (int i = 0; i < logs.Length; ++i)
            {
                sb.Append(logs[i].ToString());
                sb.Append(", ");
            }
            DoLog(StringBuilderCache.GetStringAndRelease(sb), null, LogLevel.Info);
        }

        public static void LogException(Exception e)
        {
            var sb = StringBuilderCache.Acquire();
            sb.AppendFormat("Exception: {0}", e.Message);
            if (e.InnerException != null)
            {
                sb.AppendFormat(" InnerException: {0}", e.InnerException.Message);
            }
            sb.Append(" , ").Append(e.StackTrace);
            LogErrorWithStack(StringBuilderCache.GetStringAndRelease(sb));
        }

        public static void LogErrorWithStack(string err = "", int stack = 2)
        {
            StackFrame sf = GetTopStack(stack);
            var sb = StringBuilderCache.Acquire();
            sb.AppendFormat("[ERROR]{0}\n\n{1}:{2}\t{3}", err, sf.GetFileName(), sf.GetFileLineNumber(), sf.GetMethod());
            DoLog(StringBuilderCache.GetStringAndRelease(sb), null, LogLevel.Error);
            if (LogErrorEvent != null)
            {
                LogErrorEvent(err);
            }
        }

        public static StackFrame GetTopStack(int stack = 2)
        {
            StackFrame[] stackFrames = new StackTrace(true).GetFrames();
            StackFrame sf = stackFrames[Math.Min(stack, stackFrames.Length - 1)];
            return sf;
        }

        public static void Error(string err, params object[] args)
        {
            LogErrorWithStack(string.Format(err, args), 2);
        }

        public static void LogError(string err, params object[] args)
        {
            LogErrorWithStack(string.Format(err, args), 2);
        }

        public static void Warning(string err, params object[] args)
        {
            DoLog(err, args, LogLevel.Warning);
        }

        public static void LogWarning(string err, params object[] args)
        {
            DoLog(err, args, LogLevel.Warning);
        }

        private static void DoLog(string szMsg, object[] args, LogLevel emLevel)
        {
            if (LogLevel > emLevel)
            {
                return;
            }

            if (args != null)
            {
                szMsg = string.Format(szMsg, args);
            }

            szMsg = string.Format("[{0}]{1}\n\n=================================================================\n\n",
                    DateTime.Now.ToString("HH:mm:ss.ffff"), szMsg);
            switch (emLevel)
            {
                case LogLevel.Warning:
                case LogLevel.Trace:
                    UnityEngine.Debug.LogWarning(szMsg);
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(szMsg);
                    break;
                default:
                    UnityEngine.Debug.Log(szMsg);
                    break;
            }
        }

        public static void LogToFile(string szMsg)
        {
            LogToFile(szMsg, true); // 默认追加模式
        }

        // 是否写过log file
        public static bool HasLogFile()
        {
            string fullPath = GetLogPath();
            return File.Exists(fullPath);
        }
        // 写log文件
        public static void LogToFile(string szMsg, bool append)
        {
            string fullPath = GetLogPath();
            string dir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (FileStream fileStream = new FileStream(fullPath, append ? FileMode.Append : FileMode.CreateNew,
                FileAccess.Write, FileShare.ReadWrite)) // 不会锁死, 允许其它程序打开
            {
                lock (fileStream)
                {
                    StreamWriter writer = new StreamWriter(fileStream); // Append
                    writer.Write(szMsg);
                    writer.Flush();
                    writer.Close();
                }
            }
        }
        // 用于写日志的可写目录
        public static string GetLogPath()
        {
            string logPath;
            if (IsUnityEditor)
            {
                logPath = "logs/";
            }
            else
            {
                logPath = Path.Combine(Application.persistentDataPath, "logs/");
            }
            var now = DateTime.Now;
            var logName = string.Format("game_{0}_{1}_{2}.log", now.Year, now.Month, now.Day);
            return logPath + logName;
        }
    }
}