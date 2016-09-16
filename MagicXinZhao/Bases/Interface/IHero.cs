using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace MagicAIO.Bases.Interface
{
    interface IHero
    {
        //Init
        void CreateMenu();
        void CreateVars();
        void TriggerEvents();

        //Orbwalker modes
        void PermaActiv();
        void KillSteal();

        // Events
        void Game_OnTick(EventArgs args);
    }
}
