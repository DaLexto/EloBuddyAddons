using System;
using System.Dynamic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Magnifico.Logics.MainLogics
{
    interface ILogicSelector
    {
        //Initialize Champion Base
        void CreateMenu();
        void CreateVars();
        void TriggerEvents();

        // Initialize Champion Features
        int[] skillSequence { get; }


        // Initialize Game Events
    }
}
