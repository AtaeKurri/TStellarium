using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Stellarium
{
    public static class GFX
    {

        private const string
            BUTTON_DIRECTORY = "UI/Buttons/",
            CLOSE_UI = BUTTON_DIRECTORY + "CloseUI.png";

        public static Texture2D closeUI;

        public static void LoadGFX(Mod mod)
        {
            
            closeUI = mod.GetTexture(CLOSE_UI);
        }

        public static void UnloadGFX()
        {

            closeUI = null;
        }
    }
}