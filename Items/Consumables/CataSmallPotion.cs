using Microsoft.Xna.Framework;
using Stellarium.Items.MagusClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.Consumables
{
    public class CataSmallPotion : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Regenerate 100 Cataclysm energy");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(gold: 1);
            item.potion = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>());
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            modPlayer.MagusCataCurrent += 100;
            return true;
        }

    }
}