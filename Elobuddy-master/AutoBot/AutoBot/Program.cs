using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;
using EloBuddy.Sandbox;
using Version = System.Version;
using System.Reflection;

namespace AutoBot
{
    class Program
    {
        public static string Author = "DevAkumetsu";
        public static string AddonName = "AutoBot";
        public static Menu addonMenu;
        public static Random Rnd = new Random(Environment.TickCount);

        static void Main(string[] args)
        {
            // load the addon
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            // version of addon
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string scriptVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;      
            Chat.Print(AddonName + " made by " + Author + " loaded!");            
            Chat.Print("Version Loaded" + scriptVersion);

            Console.WriteLine(AddonName + " made by " + Author + " loaded!");
            Console.WriteLine("Version Loaded" + scriptVersion);

            if (Game.MapId != GameMapId.SummonersRift)
            {
                Chat.Print(Game.MapId + " IS NOT Supported By AutoBot");
                return;
            }

            // MENU AutoBot
            addonMenu = MainMenu.AddMenu("Auto Bot", "AutoBot");
            addonMenu.AddLabel(AddonName + " made by " + Author + ", email: otaku.akumetsu@gmail.com ");
            addonMenu.AddSeparator(5);
            addonMenu.AddLabel("Activation: ");
            addonMenu.Add("menu_active_autobot", new CheckBox("Active the AutoBot?", true));
            addonMenu.Add("menu_hacks_ab", new CheckBox("Active Texture?",  false));
            addonMenu.Add("menu_chatting_ab", new CheckBox("Active Chatting BOT?", false));
            addonMenu.Add("menu_game_abdisablechat", new CheckBox("Disable Chat?", false));
            addonMenu.Add("menu_game_abclose", new CheckBox("Close the game when finish the game?", false));
     
            addonMenu.AddSeparator(5);
            addonMenu.AddGroupLabel("Others");


            Game.OnUpdate += On_Update;

        }

        private static void On_Update(EventArgs args)
        {
            // check if we need to active the addon ifself
            /*if (!addonMenu["menu_active_autobot"].Cast<CheckBox>().CurrentValue) { 
                    return;
            }
            // Setup hacks texture for BOTTING
            if (!addonMenu["menu_hacks_autobot"].Cast<CheckBox>().CurrentValue) { 
                   // Ahacks.Init();
            }
            // Setup Chatting BOT
            if (!addonMenu["menu_chatting_autobot"].Cast<CheckBox>().CurrentValue) {
                // Chatting.Init();
            }*/
        }

    }
}
