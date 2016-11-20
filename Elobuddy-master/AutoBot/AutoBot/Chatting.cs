using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using System.Reflection;
using EloBuddy.SDK.Menu.Values;

namespace AutoBot
{
    class Chatting
    {
        public static List<string> _allowed = new List<string> { "/noff", "/ff",
            "/mute all", "/msg", "/r", "/w", "/surrender", "/nosurrender", "/help",
            "/dance", "/d", "/taunt", "/t", "/joke",   "/j", "/laugh", "/l" };

        public static Random Rand = new Random(Environment.TickCount);


        public static void Init()
        {

            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

            Chat.OnInput += Chat_OnInput;
        }

        private static void Chat_OnInput(ChatInputEventArgs args)
        {
              if (MainMenu.GetMenu("AutoBot").Get<CheckBox>("menu_game_abdisablechat").CurrentValue)
              {
                  args.Process = false;
                  if (_allowed.Any(str => args.Input.StartsWith(str)))
                      args.Process = true;
              }
              else
              {
                  args.Process = true;
              }
        }


    }
}
