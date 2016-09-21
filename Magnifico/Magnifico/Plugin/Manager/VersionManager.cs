#region License
// Project:      Magnifico  
// File Name:    VersionManager.cs
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
// File Created: 2016-09-21
// Time: 16:09
//                                                                     Author: Magnifico / Aleksandar Todorov
#endregion
using System;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EloBuddy;
using Version = System.Version;

namespace Magnifico.Plugin.Manager
{
    internal static class VersionManager
    {
        private static Version ActualVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;

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
