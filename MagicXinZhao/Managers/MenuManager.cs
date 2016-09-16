using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace MagicAIO.Managers
{
    static class MenuManager
    {
        public static Menu CurrentMainMenu;
        public static Dictionary<string, Dictionary<string, Dictionary<Menu, Dictionary<string, Values>>>> Menus = new Dictionary<string, Dictionary<string, Dictionary<Menu, Dictionary<string, Values>>>>();

        public static Menu Init(string mMenuName)
        {
            Menus.Add(mMenuName, new Dictionary<string, Dictionary<Menu, Dictionary<string, Values>>>());

            return CurrentMainMenu = MainMenu.AddMenu(mMenuName, mMenuName);
        }

        public enum Values
        {
            Checkbox = 0, Slider = 1, KeyBind = 2
        };
    }
}
