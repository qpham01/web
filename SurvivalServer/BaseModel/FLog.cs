using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BaseModel
{
    public enum LCat
    {
        None,
        Action,
        Animation,
        Avatar,
        Battle,
        Camera,
        Move,
        RNG,
        Tactical,
        Count,
    }

    public enum LLevel
    {
        None,
        Trace,
        Debug,
        Info,
        Warning,
        Error,
    }

    public static class FLog 
    {
        public static string LogFilePath;
        const string logDir = "Logs";

        private static Dictionary<LCat, LLevel> logCategories = new Dictionary<LCat, LLevel>();

        public static DateTime startTime;

        static object locker = new object();

        public static void Activate(LCat category, LLevel level)
        {
            if (!logCategories.ContainsKey(category)) logCategories.Add(category, level);
            else logCategories[category] = level;
        }

        public static double Now { get { return (DateTime.Now - startTime).TotalSeconds; } }

        static FLog()
        {
            startTime = DateTime.Now;
            string path = string.Format("{0}/{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), logDir);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string fileName = string.Format("log_{0}{1:00}{2:00}-{3:00}{4:00}{5:00}.txt", startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, startTime.Second);
            LogFilePath = string.Format("{0}/{1}", path, fileName);
            for (int i = 0; i < (int)LCat.Count; ++i)
            {
                Activate((LCat)i, LLevel.Info);
            }
        }

        private static void Log(string firstValue, params object[] messageValues)
        {
            lock(locker)
            {
                using (StreamWriter w = File.AppendText(LogFilePath))
                {
                    w.WriteLine(string.Format(firstValue, messageValues));
                }
            }
        }

        public static void LogE(string firstValue, params object[] messageValues)
        {
            using (StreamWriter w = File.AppendText(LogFilePath))
            {
                w.WriteLine(string.Format("ERROR: {0}", string.Format(firstValue, messageValues)));
            }
        }

        private static void LogL(LCat category, LLevel logLevel, string message)
        {
            LLevel level = LLevel.None;
            if (logCategories.TryGetValue(category, out level) && (int)logLevel >= (int)level)
            {
                string log = category == LCat.None ? string.Format("L-{0:0.000} {1}: {2}", Now, level, message) :
                    string.Format("L-{0:0.000} {1} {2}: {3}", Now, category, level, message);
                Log(log);
            }
        }

        private static void LogL(LCat category, LLevel logLevel, string firstValue, params object[] messageValues)
        {
            LogL(category, logLevel, string.Format(firstValue, messageValues));
        }

        public static void Trace(LCat category, string firstValue, params object[] messageValues)
        {
            LogL(category, LLevel.Trace, string.Format(firstValue, messageValues));
        }

        public static void Debug(string firstValue, params object[] messageValues)
        {
            LogL(LCat.None, LLevel.Debug, string.Format(firstValue, messageValues));
        }

        public static void Debug(LCat category, string firstValue, params object[] messageValues)
        {
            LogL(category, LLevel.Debug, string.Format(firstValue, messageValues));
        }

        public static void Info(string firstValue, params object[] messageValues)
        {
            LogL(LCat.None, LLevel.Info, string.Format(firstValue, messageValues));
        }

        public static void Info(LCat category, string firstValue, params object[] messageValues)
        {
            LogL(category, LLevel.Info, string.Format(firstValue, messageValues));
        }

        public static void Dump(string message)
        {
            FLog.Log(message);
        }

        public static void Dump(string firstValue, params object[] messageValues)
        {
            Dump(string.Format(firstValue, messageValues));
        }

    }
}
