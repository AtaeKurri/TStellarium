using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;

namespace Stellarium.UI
{
    internal class MagusTeleportationDeviceUI : EasyMenu
    {
        public static bool menuvisible = false;

        private UIText _titleText;
        private UIImageButton _closeMenu;
        public UIToggleHoverImageButton muteButton;
        public static bool announce = true;

        private Player _player;
        public const float PADDINGX = 10f;
        public const float PADDINGY = 30f;
        float spacing = 8f;

        public override void OnInitialize()
        {
            announce = false;

            backPanel = new UIPanel();
            backPanel.Width.Set(306f, 0f);
            backPanel.Height.Set(128f, 0f);
            backPanel.Left.Set(Main.screenWidth / 2f - backPanel.Width.Pixels / 2f, 0f);
            backPanel.Top.Set(Main.screenHeight / 2f - backPanel.Height.Pixels / 2f, 0f);
            backPanel.BackgroundColor = new Color(73, 94, 171);
            backPanel.OnMouseDown += new MouseEvent(DragStart);
            backPanel.OnMouseUp += new MouseEvent(DragEnd);
            Append(backPanel);

            InitText(ref _titleText, "Teleportation Menu", 1, 55, -32, Color.White);

            int top = 0;
            int left = 0;

            muteButton = new UIToggleHoverImageButton(Main.magicPixel, GFX.closeUI, "Toggle Messages", announce);
            muteButton.OnClick += SelectCloseButton;
            muteButton.Left.Pixels = left;
            muteButton.Top.Pixels = top;
            backPanel.Append(muteButton);
            left += (int)spacing * 2 + 28;

            base.OnInitialize();
        }

        public static void ToggleVisibility()
        {
            menuvisible = !menuvisible;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void SelectCloseButton(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            ToggleVisibility();
        }
    }
}