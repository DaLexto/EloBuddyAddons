using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

using EloBuddy;
using EloBuddy.SDK.Events;
using Magnifico.Logics.Interfaces;
using Magnifico.Logics.MyChampions;
using Magnifico.Utilities;


namespace Magnifico
{
    internal static class Program
    {
        private static AIHeroClient MyHero => Player.Instance;



        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            VersionManager.CheckVersion();
            try
            {
                Activator.CreateInstance(null, "Magnifico.Logics.MyChampions." + MyHero.ChampionName);
                Chat.Print("MagnificoAIO - {0} Loaded, [by Magnifico]", MyHero.ChampionName);
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
            }
            
        }

        
    }
}
