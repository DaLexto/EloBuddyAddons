using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Net;
using EloBuddy;
using Version = System.Version;

namespace MrWhoAIO.Utilities
{
    static class VersionManager
    {
        public static Version ActualVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;
    }
}
