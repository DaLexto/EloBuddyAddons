using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

using EloBuddy;
//using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Magnifico.Logics.MainLogics;
using Magnifico.Utilities;
//using EloBuddy.SDK.Menu;
//using EloBuddy.SDK.Menu.Values;
using Magnifico.Logics.MyChampions; 

namespace Magnifico
{
    internal static class Program
    {
        private static AIHeroClient MyHero => Player.Instance;
        private static ILogicSelector Logic { get; set; }


        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            try
            {
                Activator.CreateInstance(null, MyHero.ChampionName);
                Chat.Print("Mr. Who AIO Loaded!", Color.White);
                Chat.Print("Version: {0}", VersionManager.ActualVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        
    }
}
