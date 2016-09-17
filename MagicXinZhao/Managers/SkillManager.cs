using System;
using System.Linq;
using System.Threading;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace MagicAIO.Managers
{
    class SkillManager
    {
        //public static int[] AbbilitySequence;
        public static int qOff = 0, wOff = 0, eOff = 0, rOff;
        public static string RoleType = "";
        public static int[] Level = { 0, 0, 0, 0 };

        public Menu menu { get; set; }

        readonly AIHeroClient Player = EloBuddy.Player.Instance;

        public SkillManager()
        {

            menu = MenuManager.AddSubbMenu("Skill Manager");
            {
                menu.NewCheckbox("disable", "Disable");
                menu.NewSlider("skilldelay", "Delay to Level Up Skill (ms)", 1000, 0, 10000, true);
            }

        }
    }
}
