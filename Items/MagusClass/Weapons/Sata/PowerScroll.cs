using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Sata
{
    public class PowerScroll : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
            Tooltip.SetDefault("Increases all Magus damage by 10%\n'No, it's not a potion, it's a weapon'");
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(60, 62);
            item.knockBack = 0;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.autoReuse = false;
            item.useTime = 15;
            item.useAnimation = 15;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.potion = false;

            MagusSataCost = 10;
            MagusType = 2; // Sata
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 20);
            recipe.AddIngredient(ItemID.MeteoriteBar, 3);
            recipe.AddIngredient(ItemType<Materials.SatanismEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffType<Buffs.PowerScrollBuff>(), 900, false);
            return true;
        }
    }
}