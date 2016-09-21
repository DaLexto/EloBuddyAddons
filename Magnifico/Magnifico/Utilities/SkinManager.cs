using System;
using EloBuddy;
using EloBuddy.SDK.Menu;


namespace Magnifico.Utilities
{
    class SkinManager
    {
        public Menu menu { get; set; }

        readonly AIHeroClient _player = EloBuddy.Player.Instance;

        public SkinManager(int skins)
        {
            //Creating menu
           menu = MenuManager.AddSubbMenu("Skin Manager");
            {
                menu.NewCheckbox("enable", "Enable");
                menu.NewSlider("skinid", "SkinID", 0, 0, skins, true);
            }

            Game.OnTick += Game_OnTick;
        }

        private void Game_OnTick(EventArgs args)
        {
            if (_player.SkinId != menu.Value("skinid") && menu.IsActive("enable"))
            {
                _player.SetSkinId(menu.Value("skinid"));
            }

            return;
        }
    }
}
