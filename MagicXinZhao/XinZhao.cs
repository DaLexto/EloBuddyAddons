using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using MagicAIO.Bases;
using MagicAIO.Managers;
using Circle = EloBuddy.SDK.Rendering.Circle;
//using ScaleTypes = MagicAIO.Managers.DemageManager.ScaleTypes;

namespace MagicAIO
{
    class XinZhao : ChampBase
    {
        readonly AIHeroClient Player = EloBuddy.Player.Instance;

        float ETime;

        readonly Spell.Active Q = new Spell.Active(SpellSlot.Q);
        readonly Spell.Active W = new Spell.Active(SpellSlot.W);
        readonly Spell.Targeted E = new Spell.Targeted(SpellSlot.E, 600);
        readonly Spell.Active R = new Spell.Active(SpellSlot.R, 187);

        public int[] abilitySequence = new[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 2, 4, 2, 3, 2, 3, 4, 2, 3 };


        public override void CreateMenu()
        {
            base.CreateMenu();

            var menu = MenuManager.AddSubbMenu("Drawings");
            {
                menu.NewCheckbox("disable", "Disable");
                menu.NewCheckbox("demageindicator", "Demage Indicator");
                menu.NewCheckbox("e","E Range", true, true);
                menu.NewCheckbox("r", "R Range");
            }

            menu = MenuManager.AddSubbMenu("Combo");
            {

            }

            menu = MenuManager.AddSubbMenu("Lane Clear");
            {

            }

            menu = MenuManager.AddSubbMenu("Jungle Clear");
            {

            }

            menu = MenuManager.AddSubbMenu("Harass");
            {

            }

            menu = MenuManager.AddSubbMenu("Last Hit");
            {

            }

        }

        public override void CreateVars()
        {
            new SkinManager(7);
            new SkillLevelUp(abilitySequence);
        }

        public override void Drawing_OnDraw(EventArgs args)
        {
            if (Player.IsDead || draw.IsActive("disable"))
                return;

            if (draw.IsActive("e"))
                Circle.Draw(E.IsReady() ? Color.Blue : Color.Red, E.Range, Player.Position);

            if (draw.IsActive("r"))
                Circle.Draw(R.IsReady() ? Color.Blue : Color.Red, R.Range, Player.Position);
            
            return;
        }
    }
}
