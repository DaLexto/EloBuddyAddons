#region License
// Project:      Magnifico  
// File Name:    Program.cs
// 
// THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CREATIVE COMMONS 
// PUBLIC LICENSE ("CCPL" OR "LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT AND/OR OTHER 
// APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR 
// COPYRIGHT LAW IS PROHIBITED.
//                                                                                                                                                                                  
// BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HERE, YOU ACCEPT AND AGREE TO BE BOUND          
// BY THE TERMS OF THIS LICENSE. TO THE EXTENT THIS LICENSE MAY BE CONSIDERED TO BE A CONTRACT,    
// THE LICENSOR GRANTS YOU THE RIGHTS CONTAINED HERE IN CONSIDERATION OF YOUR ACCEPTANCE     
// OF SUCH TERMS AND CONDITIONS.
// 
// 
// File Created: 2016-09-21
// Time: 15:10
//                                                                     Author: Magnifico / Aleksandar Todorov
#endregion
using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using Magnifico.Plugin.Champions;
using Magnifico.Plugin.Manager;

namespace Magnifico
{
    internal class Program
    {
        private static AIHeroClient MyHeroClient => Player.Instance;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            
            /* DEBUG
            TestApp();
            */
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
          {
              try
              {
                  if (
                      (ChampBase)
                      Activator.CreateInstance(null,
                              "Magnifico.Plugin.Champions." + MyHeroClient.ChampionName + "." + MyHeroClient.ChampionName)
                          .Unwrap() != null)
                  {
                      VersionManager.CheckVersion();
                  }
                 
              }
              catch (Exception e)
              {
                  // TODO: Make ErrorHandler
                  Console.WriteLine(e);
              }
          }

        /* private static void TestApp()
        {
            var champ = "Jax";
            try
            {
                if (
                    (ChampBase)
                    Activator.CreateInstance(null,
                            "Magnifico.Plugin.Champions." + champ + "." + champ)
                        .Unwrap() != null)
                    Console.WriteLine("Uspeh");
            }
            catch (Exception e)
            {
                // NOTE: Make ErrorHandler
                Console.WriteLine(e + "\nThis Addon still don't support: " + champ);
            }
        }*/
    }
}
