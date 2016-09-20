using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using AceAIO.Utilities.MenuManager;

namespace AceAIO.Logics.ChampionLogic
{
    class XinZhao : IChampion
    {

        public Spell.Targeted E;
        public Spell.Active Q, W, R;

        public XinZhao()
        {
            skillSequence = new[] {1, 2, 3, 1, 1, 4, 1, 3, 1, 2, 4, 2, 3, 2, 3, 4, 2, 3};

            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 600);
            R = new Spell.Active(SpellSlot.R, 187);
        }

        public void CreateMenu()
        {
            var menu = MenuManager.AddSubbMenu("Drawings");
            {
                menu.NewCheckbox("disable", "Disable");
            }
        }

        public int[] skillSequence { get; private set; }
        public LogicSelector Logic { get; set; }

        
    }
}
