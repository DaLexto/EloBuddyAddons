using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using Magnifico.Logics.Interfaces;
using SharpDX;

using Magnifico.Utilities;

using Circle = EloBuddy.SDK.Rendering.Circle;

namespace Magnifico.Logics.MyChampions
{
    internal class XinZhao :  ChampBase
    {
        
        private static string MyChampName => Player.Instance.ChampionName;
        ///private static AutoSkillUp skillUp;

        private readonly Spell.Active Q = new Spell.Active(SpellSlot.Q);
        private readonly Spell.Active W = new Spell.Active(SpellSlot.W);
        private readonly Spell.Targeted E = new Spell.Targeted(SpellSlot.E, 600);
        private readonly Spell.Active R = new Spell.Active(SpellSlot.R, 187);

        private readonly AIHeroClient _myChamp = Player.Instance;
        
        
        public override void CreateChampMenu()
        {
            base.CreateChampMenu();
                
            var menu = MenuManager.AddSubbMenu("Drawings");
            {
                menu.NewCheckbox("disable", "Disable Drawings");
                menu.NewCheckbox("dER", "E Range");
                menu.NewCheckbox("dRR", "R Range");
            }
                

            menu = MenuManager.AddSubbMenu("Combo");
            {
                
            }

            menu = MenuManager.AddSubbMenu("Harass");
            {
                
            }

            menu = MenuManager.AddSubbMenu("Lane Clear");
            {

            }

            menu = MenuManager.AddSubbMenu("Jungle Clear");
            {

            }

            menu = MenuManager.AddSubbMenu("Last Hit");
            {

            }

            menu = MenuManager.AddSubbMenu("Misc");
            {

            }


        }

        public override void CreateVars()
        {
            skillSequence = new[] { 1, 2, 3, 1, 1, 4, 1, 3, 1, 2, 4, 2, 3, 2, 3, 4, 2, 3 };
            new AutoSkillUp(skillSequence);
            new SkinManager(7);
        }

        public override void Drawing_OnDraw(EventArgs args)
        {
            if (_myChamp.IsDead || DrawingMenu.IsActive("disable"))
                return;

            if(DrawingMenu.IsActive("dER"))
                Circle.Draw(E.IsReady() ? Color.Blue : Color.Red, E.Range, _myChamp.Position);

            if(DrawingMenu.IsActive("dRR"))
                Circle.Draw(R.IsReady() ? Color.AliceBlue : Color.Red, R.Range, _myChamp.Position);
        }

    }
}
