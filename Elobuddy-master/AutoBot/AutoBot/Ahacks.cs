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

namespace AutoBot
{
    class Ahacks
    {      
     
        public static void Init()
        {

            Hacks.DisableTextures = true;
            Hacks.AntiAFK = true;
            Hacks.RenderWatermark = false;

            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

            ManagedTexture.OnLoad += ManagedTexture_OnLoad;
        }

        private static void ManagedTexture_OnLoad(OnLoadTextureEventArgs args)
        {

            args.Process = false;
        }
    }
}
