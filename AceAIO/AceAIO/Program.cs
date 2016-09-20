using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Color = System.Drawing;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
//using EloBuddy.SDK.Menu;
//using EloBuddy.SDK.Menu.Values;
using SharpDX;
using SharpDX.Direct3D9;
using Version = System.Version;

using AceAIO.Logics;
using AceAIO.Logics.ChampionLogic;
//using AceAIO.Logics.CombatLogic;
using AceAIO.Utilities;
//using AceAIO.Utilities.AutoLevelUp;
using AceAIO.Utilities.MenuManager;


namespace AceAIO
{
    internal static class Program
    {
        //Create Instance of Selected Champion
        private static AIHeroClient MyHero => Player.Instance;
        private static IChampion myChampion;
        private static LogicSelector Logic { get; set; }

        public static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            // For Debuging ONLY
            Chat.Print("Champion Name is: " + MyHero.ChampionName);

           // LogicSelector()
           
           
            
        }
    }
}
