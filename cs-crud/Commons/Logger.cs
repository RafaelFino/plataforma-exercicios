using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Commons
{
    public class LogItem
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public LogItem(string message)
        {
            Timestamp = DateTime.Now;
            Message = message;
        }

        public override string ToString()
        {
            return $"[{Timestamp}] {Message}";
        }
    }
    public class Logger
    {
        private static Logger? _logger;
        private readonly ConcurrentQueue<LogItem> _logItems = new ConcurrentQueue<LogItem>();

        private static bool _enable;

        private Logger()
        {
            _enable = true;
            Task backgroundTask = Task.Run(() =>
            {
                LogItem? message;
                while(_enable)
                {
                    while(_logItems.TryDequeue(out message))                
                    {
                        if(message != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"[{message.Timestamp:yyyy-MM-dd HH:mm:ss}]");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(message.Message);
                            Console.ResetColor();
                        }
                    }
                    Thread.Sleep(1000);   
                }                
            });
        }

        public static Logger GetInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }        

        public void Stop()
        {
            _enable = false;
        }

        public void Log(string message)
        {
            _logItems.Enqueue(new LogItem(message));
        }

        public void Log(string message, Exception exception)
        {
            _logItems.Enqueue(new LogItem($"{message} - Exception: {exception.Message}"));            
        }
    }
}