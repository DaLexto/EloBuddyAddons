using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using MagicAIO.Managers;

namespace MagicAIO
{
    class Program
    {
        static void Main(string[] args) { Loading.OnLoadingComplete += OnGameLoadComplete; }

        private static void OnGameLoadComplete(EventArgs args)
        {
            VersionManager.CheckVersion();

            try
            {
                Activator.CreateInstance(null, "MagicAIO." + Player.Instance.ChampionName);
                Chat.Print("Magic{0} Loaded, [By Magnifico], Version: {1}", Player.Instance.ChampionName == "XinZhao" ? "Zhao" : Player.Instance.ChampionName, VersionManager.ActualVersion);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
