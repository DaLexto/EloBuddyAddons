using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using Magnifico.Logics.Interfaces;

namespace Magnifico.Logics.MyChampions
{
    class XinZhao : IChampion
    {
        private readonly AIHeroClient _myChamp = Player.Instance;
    }
}
