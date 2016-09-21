using System;
using System.Linq;

using EloBuddy;
using EloBuddy.SDK.Menu;

using Magnifico.Logics.Interfaces;
using Magnifico.Utilities;

namespace Magnifico.Logics
{
    internal abstract class ChampBase : IChampion
    {
        private static string ChampName => Player.Instance.ChampionName;

        // Create Champion Sub-Menus
        protected Menu DrawingMenu;
        protected Menu ComboMenu;
        protected Menu HarasssMenu;
        protected Menu LaneClrMenu;
        protected Menu JungleClrMenu;
        protected Menu LastHitMenu;
        protected Menu MiscMenu;

        private readonly AIHeroClient _myChampion = Player.Instance;

        public int[] skillSequence { get; set; }

        protected ChampBase()
        {
            CreateChampMenu();

            DrawingMenu = MenuManager.GetMenu("Drawings");
            ComboMenu = MenuManager.GetMenu("Combo");
            HarasssMenu = MenuManager.GetMenu("Harass");
            LaneClrMenu = MenuManager.GetMenu("Lane Clear");
            JungleClrMenu = MenuManager.GetMenu("Jungle Clear");
            LastHitMenu = MenuManager.GetMenu("Last Hit");
            MiscMenu = MenuManager.GetMenu("Misc");

            CreateVars();
            TriggerEvents();
        }

        public virtual void CreateChampMenu()
        {
            MenuManager.Init(ChampName);
        }

        public virtual void CreateVars()
        {
           
        }

        public virtual void TriggerEvents()
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        public virtual void Drawing_OnDraw(EventArgs args){}

        public virtual void Game_OnTick(EventArgs args)
        {
            if (_myChampion.IsDead)
                return;
        }
    }
}
