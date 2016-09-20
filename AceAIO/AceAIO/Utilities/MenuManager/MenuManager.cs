using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AceAIO.Utilities.MenuManager
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

        public static Menu AddSubbMenu(string sMenuName, Menu mMenu = null)
        {
            if (mMenu != null)
            {
                // Add the submenu id to the Menu list
                Menus[mMenu.DisplayName].Add(sMenuName, new Dictionary<Menu, Dictionary<string, Values>>());

                // Add the submenu to the Menus list and init the list of ids and values
                Menus[mMenu.DisplayName][sMenuName].Add(mMenu.AddSubMenu(sMenuName, sMenuName), new Dictionary<string, Values>());

                // Return Menus
                return Menus[mMenu.DisplayName][sMenuName].Keys.Last();
            }

            // Add the submenu id's to the Menus list
            Menus[CurrentMainMenu.DisplayName].Add(sMenuName, new Dictionary<Menu, Dictionary<string, Values>>());

            // Add the submenu to the Menus list and init the list of ids and values
            Menus[CurrentMainMenu.DisplayName][sMenuName].Add(CurrentMainMenu.AddSubMenu(sMenuName, sMenuName), new Dictionary<string, Values>());

            return Menus[CurrentMainMenu.DisplayName][sMenuName].Keys.Last();
        }

        #region Menu.Values

        public enum Values
        {
            Checkbox = 0, Slider = 1, KeyBind = 2
        };

        public static void NewCheckbox(this Menu menu, string identifier, string displayName, bool defaultValue = true, bool separatorBefore = false)
        {
            if (separatorBefore)
                menu.AddSeparator();

            menu.Add(identifier, new CheckBox(displayName, defaultValue));

            Menus[menu.Parent.DisplayName][menu.DisplayName][menu].Add(identifier, Values.Checkbox);
        }

        public static void NewSlider(this Menu menu, string identifier, string displayName, int defaultValue, int minValue, int maxValue, bool separatorBefore = false)
        {
            if (separatorBefore)
                menu.AddSeparator();

            menu.Add(identifier, new Slider(displayName, defaultValue, minValue, maxValue));

            Menus[menu.Parent.DisplayName][menu.DisplayName][menu].Add(identifier, Values.Slider);
        }

        public static void NewKeybind(this Menu menu, string identifier, string displayName, bool defaultValue, KeyBind.BindTypes bindType, char key, bool separatorBefore = false)
        {
            if (separatorBefore)
                menu.AddSeparator();

            menu.Add(identifier, new KeyBind(displayName, defaultValue, bindType, key));

            Menus[menu.Parent.DisplayName][menu.DisplayName][menu].Add(identifier, Values.KeyBind);
        }

        #endregion

        public static bool IsActive(this Menu menu, string identifier)
        {
            return (bool)Return(menu, identifier);
        }

        public static int Value(this Menu menu, string identifier)
        {
            return (int)Return(menu, identifier);
        }

        public static object Return(this Menu menu, string identifier)
        {
            if (!Menus[menu.Parent.DisplayName][menu.DisplayName][menu].Keys.Any(it => it == identifier))
            {
                Console.WriteLine("The Menu Identifier {0} doesn't exists!!!", identifier);
                return null;
            }

            switch (Menus[menu.Parent.DisplayName][menu.DisplayName][menu][identifier])
            {
                case Values.Checkbox:
                    return menu[identifier].Cast<CheckBox>().CurrentValue;

                case Values.Slider:
                    return menu[identifier].Cast<Slider>().CurrentValue;

                case Values.KeyBind:
                    return menu[identifier].Cast<KeyBind>().CurrentValue;

                default:
                    return null;
            }
        }
    }
}
