namespace Magnifico.Plugin.Manager
{
    internal class LogManager
    {
        public enum LogLevel
        {
            Error,
            Info,
            Warn,
        }

        public static bool Sender(string msg, LogLevel level)
        {
            var date = DateTime.Now.ToString("HH:mm:ss - ") + "Magnifico ";
            var message = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    message = date + " Info] ";
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    message = date + " Warn] ";
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    message = date + " Error] ";
                    break;
            }
            Console.WriteLine(message + msg);
            Console.ResetColor();
            return true;
        }

        public static void Sender(string msg, Exception exc, LogLevel level)
        {
            var date = DateTime.Now.ToString("HH:mm:ss - ") + "Magnifico ";
            var message = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    message = date + " Info] ";
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    message = date + " Warn] ";
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    message = date + " Error] ";
                    break;
            }
            Console.WriteLine(message + msg);
            Console.WriteLine(exc);
            Console.ResetColor();
        }
    }
}
