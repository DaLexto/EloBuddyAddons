using System;
using System.Linq;
using System.Threading;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace MagicAIO.Managers
{
    class SkillLevelUp
    {
        public static int[] AbbilitySequence;
        public static int qOff = 0, wOff = 0, eOff = 0, rOff;
        public static string RoleType = "";
        public static int[] Level = { 0, 0, 0, 0 };

        public Menu menu { get; set; }

        readonly AIHeroClient Player = EloBuddy.Player.Instance;


        public SkillLevelUp(int[] abilitySequence)
        {
            AbbilitySequence = abilitySequence;

            menu = MenuManager.AddSubbMenu("Skill Manager");
            {
                menu.NewCheckbox("disable", "Disable");
                menu.NewSlider("skilldelay", "Delay to Level Up Skill (ms)", 1000, 0, 10000, true);
            }

            Game.OnTick += Game_OnTick;
        }

        private void Game_OnTick(EventArgs args)
        {
            try
            {

                // Debug
                Chat.Print("Q Array: " + Level[0]);
                Chat.Print("W Array: " + Level[1]);
                Chat.Print("E Array: " + Level[2]);
                Chat.Print("R Array: " + Level[3]);

                var qL = Player.Spellbook.GetSpell(SpellSlot.Q).Level + qOff;
                var wL = Player.Spellbook.GetSpell(SpellSlot.W).Level + wOff;
                var eL = Player.Spellbook.GetSpell(SpellSlot.E).Level + eOff;
                var rL = Player.Spellbook.GetSpell(SpellSlot.R).Level + rOff;

                Level = new[] { 0, 0, 0, 0 };

                for (var i = 1; i <= ObjectManager.Player.Level; i++)
                {
                    switch (AbbilitySequence[i - 1])
                    {
                        case 1:
                            Level[0] += 1;
                            break;
                        case 2:
                            Level[1] += 1;
                            break;
                        case 3:
                            Level[2] += 1;
                            break;
                        case 4:
                            Level[3] += 1;
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
