using System;
using System.IO;

namespace EdBoxPremium.Core
{
    public static class ActivityLogger
    {
        public static void LogAudit(string email, string data)
        {
            Log("AUDIT", $"{email} made changes in {data}");
        }

        public static void Log(Exception exception)
        {
            Log("ERROR>>" + exception.Source, "[" + exception + "]" + exception.Message);
        }

        public static void Log(string messageType, string message)
        {
            while (!LogEngine(messageType, message.Length >= 2000 ? message.Substring(0, 2000) : message))
            { }
        }

        private static bool LogEngine(string messageType, string message)
        {
            try
            {
                var location = System.Web.Hosting.HostingEnvironment.MapPath("~/logs");

                var dirInfo = new DirectoryInfo(location);
                if (!dirInfo.Exists)
                {
                    Directory.CreateDirectory(location);
                }

                location = location + "/";

                if (!File.Exists(location + "EdBoxPremium_Trace_Logs.txt"))
                {
                    using (var sw = File.CreateText(location + "EdBoxPremium_Trace_Logs.txt"))
                    {
                        sw.WriteLine("[" + messageType + "] " + DateTime.Now + ": " + message);
                        sw.Close();
                    }
                }
                else
                    using (var sw = File.AppendText(location + "EdBoxPremium_Trace_Logs.txt"))
                    {
                        var fI = new FileInfo(location + "EdBoxPremium_Trace_Logs.txt");
                        if (fI.Length <= Setting.LogRollOver)
                        {
                            sw.WriteLine("[" + messageType + "] " + DateTime.Now + ": " + message);
                            sw.Close();
                        }
                        else
                        {
                            sw.Close();
                            File.Move(location + "EdBoxPremium_Trace_Logs.txt", location + "EdBoxPremium_Trace_Logs_" + DateTime.Now.ToString("yyyymmddhhMMsstt"));

                            using (var sw3 = File.CreateText(location + "EdBoxPremium_Trace_Logs.txt"))
                            {
                                sw3.WriteLine("[" + messageType + "] " + DateTime.Now + ": " + message);
                                sw3.Close();
                            }
                        }
                    }
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
