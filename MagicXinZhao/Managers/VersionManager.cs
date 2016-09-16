using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Net;
using EloBuddy;
using Version = System.Version;

namespace MagicAIO.Managers
{
    class VersionManager
    {
        public static Version ActualVersion 
        { 
            get { return Assembly.GetExecutingAssembly().GetName().Version; } 
        }
        /*
        public static void CheckVersion()
        {
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var champ = Player.Instance.ChampionName == "XinZhao" ? "Zhao" : Player.Instance.ChampionName;

                        string Text = new WebClient().DownloadString("https://raw.githubusercontent.com/Magnif1co/EloBuddyAddons/master/Magic" + champ + "/Properties/AssemblyInfo.cs");

                        var Match = new Regex(@"\[assembly\: AssemblyVersion\(""(\d+)\.(\d+)\.(\d+)\.(\d+)""\)]").Match(Text);

                        if (Match.Success)
                        {
                            var CorrectVersion = new Version (string.Format("{0}.{1}.{2}.{3}", Match.Groups[1], Match.Groups[2], Match.Groups[3], Match.Groups[4]));

                            if(CorrectVersion > ActualVersion)
                            {
                                Chat.Print("<font color='FFFF00'>Your Magic{0} is </font><font color='#FF0000'>OUTDATED</font><font color='FFFF00'>, The correcty version is: " + CorrectVersion + "</font>", champ);
                            }
                            else
                            {
                                Chat.Print("<font color='FFFF00'>You using </font><font color='#FF0000'>Magic - {0}</font><font color='FFFF00'>, Version: " + ActualVersion + "</font>", champ);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e + "\n");
                    }

                });

        }*/
    }
}
