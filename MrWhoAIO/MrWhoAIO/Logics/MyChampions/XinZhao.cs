using EloBuddy;
using EloBuddy.SDK;
using MrWhoAIO.Utilities;

namespace MrWhoAIO.Logics.MyChampions
{
    internal class XinZhao : ChampLogic
    {

        public Spell.Active Q, W, E, R;
        public override int[] skillSequence { get; set; } = new[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };

        public XinZhao()
        {
            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, 600);
            R = new Spell.Active(SpellSlot.R, 187);

            //CreateMenu();
        }

        public override void CreateMenu()
        {
            base.CreateMenu();

            var menu = MenuManager.AddSubbMenu("Drawings");
            {
                menu.NewCheckbox("disable", "Disable");
                menu.NewCheckbox("e", "E Range");
                menu.NewCheckbox("r", "R Range");
            }
        }
    }
}
