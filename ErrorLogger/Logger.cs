using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLogger
{
    public class Logger
    {
        public static void LogError(string errorLogPath, string error)
        {
            using (var sw = new StreamWriter(errorLogPath, true))
            {
                if (!string.IsNullOrWhiteSpace(errorLogPath))
                {
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        sw.WriteLine($"Date And Time: {DateTime.Now}{Environment.NewLine}Error Message: {error}");
                        sw.WriteLine($"--------------------------------------------------------------------------------");
                    }
                    else
                    {
                        sw.WriteLine($"Date And Time: {DateTime.Now}{Environment.NewLine}Error Message: The passed in error string was empty.");
                        sw.WriteLine($"--------------------------------------------------------------------------------");
                    }
                }
                else
                {
                    sw.WriteLine($"Date And Time: {DateTime.Now}{Environment.NewLine}Error Message: The passed in error log path string was empty.");
                    sw.WriteLine($"--------------------------------------------------------------------------------");
                }
            }
        }
    }
}
