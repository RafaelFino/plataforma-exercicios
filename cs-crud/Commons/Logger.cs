using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Commons
{
    public class Logger
    {
        private static readonly Logger _logger = new Logger();

        public static Logger GetInstance()
        {
            return _logger;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }

        public string Log(string message, Exception exception)
        {
            string logMessage = $"[{DateTime.Now}] {message} - Exception: {exception.Message}";
            Console.WriteLine(logMessage);
            return logMessage;
        }
    }
}