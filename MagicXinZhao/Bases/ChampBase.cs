using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using MagicAIO.Bases.Interface;
using MagicAIO.Managers;

namespace MagicAIO.Bases
{
    abstract class ChampBase : IHero
    {
        public static DemageManager demageManager { get; set; }

        public static string CHAMP_MENU { get { return "Magic" + EloBuddy.Player.Instance.ChampionName; } }

        // Create Champion Menus
        protected Menu draw;
        protected Menu combo;
        protected Menu skills;

        readonly AIHeroClient Player = EloBuddy.Player.Instance;

        protected ChampBase()
        {
            CreateMenu();

            draw = GetMenu("Drawings");
            combo = GetMenu("Combo");
            skills = GetMenu("Skill Manager");

            CreateVars();
            TriggerEvents();
        }

        private Menu GetMenu(string dispayMenuName)
        {
            if(MenuManager.Menus[CHAMP_MENU].Keys.Any(it => it == dispayMenuName))
                return MenuManager.Menus[CHAMP_MENU][dispayMenuName].Keys.Last();

            return null;
        }

        public virtual void CreateMenu()
        {
            MenuManager.Init(CHAMP_MENU);
        }

        public virtual void TriggerEvents()
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }
        

        public virtual void CreateVars()
        {

        }

        public virtual void KillSteal()
        {

        }

        public virtual void PermaActiv()
        {
            KillSteal();
        }

        public virtual void Game_OnTick(EventArgs args)
        {
            if (Player.IsDead)
                return;

            // Make Kill Stealing Perma Activ
            PermaActiv();
        }

        public virtual void Drawing_OnDraw(EventArgs args)
        {

        }

    }
}
