#region License
// Project:      Magnifico  
// File Name:    LogManager.cs
// 
// THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CREATIVE COMMONS 
// PUBLIC LICENSE ("CCPL" OR "LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT AND/OR OTHER 
// APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR 
// COPYRIGHT LAW IS PROHIBITED.
//                                                                                                                                                                                  
// BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HERE, YOU ACCEPT AND AGREE TO BE BOUND          
// BY THE TERMS OF THIS LICENSE. TO THE EXTENT THIS LICENSE MAY BE CONSIDERED TO BE A CONTRACT,    
// THE LICENSOR GRANTS YOU THE RIGHTS CONTAINED HERE IN CONSIDERATION OF YOUR ACCEPTANCE     
// OF SUCH TERMS AND CONDITIONS.
// 
// 
// File Created: 2016-09-22
// Time: 02:18
//                                                                     Author: Magnifico / Aleksandar Todorov
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
