using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Magnifico.Logics.Interfaces
{
    interface IChampion
    {
        // Initialization of champion base
        int[] skillSequence { get; }
        void CreateChampMenu();
        void CreateVars();
        void TriggerEvents();

        //Check for Orbwalker modes

        // Fire-Up Events
        void Game_OnTick(EventArgs args);
        void Drawing_OnDraw(EventArgs args);
    }
}
