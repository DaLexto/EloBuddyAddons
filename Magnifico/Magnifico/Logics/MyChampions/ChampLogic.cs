using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using Magnifico.Logics.MainLogics;
using Magnifico.Utilities;

namespace Magnifico.Logics.MyChampions
{
    abstract class ChampLogic : ILogicSelector
    {
        private static string ChampMenu => EloBuddy.Player.Instance.ChampionName;
        private readonly AIHeroClient _myChamp = Player.Instance;

        public virtual int[] skillSequence
        {
            get { return skillSequence; }
            set { skillSequence = value; }
        }

        protected ChampLogic()
        {
            CreateMenu();

            CreateVars();
            TriggerEvents();
        }

        public virtual void TriggerEvents()
        {
            throw new NotImplementedException();
        }

        public virtual void CreateVars()
        {
            throw new NotImplementedException();
        }

        public virtual void CreateMenu()
        {
            MenuManager.Init(ChampMenu);
        }
    }
}
