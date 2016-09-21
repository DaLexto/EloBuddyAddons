using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Magnifico.Logics.Interfaces;

namespace Magnifico.Utilities
{
    class AutoSkillUp
    {
        public static int[] SkillSequence;

        private readonly SpellDataInst q = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q);
        private readonly SpellDataInst w = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W);
        private readonly SpellDataInst e = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E);
        private readonly SpellDataInst r = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R);

        public Menu menu { get; set; }
        public static int Delay;

        public AutoSkillUp(int[] skillSeq)
        {
            SkillSequence = skillSeq;
            menu = MenuManager.AddSubbMenu("Auto Skill");
            menu.NewCheckbox("skillup", "Disable");
            menu.NewSlider("delay", "Maximum Delay Randomize", 1000, 0, 10000, true);

            Delay = menu.Value("delay");
            Core.DelayAction(() => OnLevelUp(ObjectManager.Player.Level), Delay);
            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        private void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if(sender != ObjectManager.Player)
                return;
            if (menu.IsActive("skillup"))
                return;
            Core.DelayAction(() => OnLevelUp(args.Level), Delay);
        }

        private void OnLevelUp(int playerLevel)
        {
            for (int c = 0; c < playerLevel; c++)
            {
                int qWish = 0, wWish = 0, eWish = 0, rWish = 0;
                for (int i = 0; i < ObjectManager.Player.Level; i++)
                {
                    switch (SkillSequence[i])
                    {
                        case 1:
                            qWish++;
                            break;
                        case 2:
                            wWish++;
                            break;
                        case 3:
                            eWish++;
                            break;
                        case 4:
                            rWish++;
                            break;
                    }
                }

                if (r.Level < rWish)
                    ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.R);
                if (q.Level < qWish)
                    ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.Q);
                if (w.Level < wWish)
                    ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.W);
                if (e.Level < eWish)
                    ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.E);
            }
        }
    }
}
