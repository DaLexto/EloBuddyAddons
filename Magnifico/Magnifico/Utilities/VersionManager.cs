using System;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EloBuddy;
using Version = System.Version;

namespace Magnifico.Utilities
{
    internal static class VersionManager
    {
        public static Version ActualVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;

        public static void CheckVersion()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var vText =
                        new WebClient().DownloadString(
                            "https://raw.githubusercontent.com/Magnif1co/EloBuddyAddons/master/Magnifico/Magnifico/Properties/AssemblyInfo.cs");
                    var vMatch =
                        new Regex(@"\[assembly\: AssemblyVersion\(""(\d+)\.(\d+)\.(\d+)\.(\d+)""\)]").Match(vText);
                    if (vMatch.Success)
                    {
                        var correctVersion =
                            new Version($"{vMatch.Groups[1]}.{vMatch.Groups[2]}.{vMatch.Groups[3]}.{vMatch.Groups[4]}");
                        if (correctVersion > ActualVersion)
                            Chat.Print(
                                "<font color='FFFF00'>Your Magnifico AIO is</font><font color='FF0000'> OUTDATED</font><font color='FFFF00'>, The correct version is:</font><font color='FFFFFF'> " +
                                correctVersion +
                                "</font><font color='FFFF00'>, Please update your addon to latest version!!!</font>");
                        else
                            Chat.Print(
                                "<font color='FFFF00'>You are using </font><font color='35DB00'>Magnifico AIO </font><font color='FFFF00'>Version: </font><font color='FFFFFF'>" +
                                correctVersion + "</font>");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "\n");
                }
            });
        }
    }
}