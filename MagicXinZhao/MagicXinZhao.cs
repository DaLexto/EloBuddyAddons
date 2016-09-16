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
    class MagicXinZhao : ChampBase
    {
        readonly AIHeroClient Player = EloBuddy.Player.Instance;

        public override void CreateMenu()
        {
            base.CreateMenu();
        }
    }
}
