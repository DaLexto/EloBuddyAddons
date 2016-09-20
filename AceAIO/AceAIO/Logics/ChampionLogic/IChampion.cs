using EloBuddy;

namespace AceAIO.Logics.ChampionLogic
{
    internal interface IChampion
    {
        // Init
        void CreateMenu();

        int[] skillSequence { get; }
        LogicSelector Logic { set; }
    }
}
