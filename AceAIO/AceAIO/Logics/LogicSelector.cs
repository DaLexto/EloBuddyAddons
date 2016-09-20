using System;
using System.Collections.Generic;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

using AceAIO.Logics.ChampionLogic;
using AceAIO.Utilities.MenuManager;

namespace AceAIO.Logics
{
    internal class LogicSelector
    {

        readonly IChampion myChamp;
        static string MyChamp => Player.Instance.ChampionName;

        public LogicSelector(IChampion my)
        {
            myChamp = my;
            //myChamp.CreateMenu();
        }
    }
}
