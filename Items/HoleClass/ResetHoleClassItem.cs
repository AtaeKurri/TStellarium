using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Stellarium.Items.HoleClass;

namespace Stellarium.Items.HoleClass
{
    public class ResetHoleClassItem : HoleClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
            Tooltip.SetDefault("!!! RESETS THE WHOLE HOLE CLASS. CAN'T BE UNDONE\nPROCEED WITH CAUTION !!!\n" +
                "This is a dev item. Don't use it in your normal playthrough.");
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(48, 48);
            item.damage = 0;
            item.knockBack = 0;
            item.rare = ItemRarityID.Gray;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = false;
            item.useTime = 1;
            item.useAnimation = 1;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;

            HoleCost = 0;
        }

        public override bool UseItem(Player player)
        {
            HoleClassDamagePlayer.ModPlayer(player).ResetAllMagus();
            return true;
        }
    }
}