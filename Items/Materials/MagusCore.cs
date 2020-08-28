using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.Materials
{
    class MagusCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magus Core");
            Tooltip.SetDefault("'The core material of all Magus tools'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OyIngot>(), 2);
            recipe.AddIngredient(ItemType<SatanismEssence>(), 10);
            recipe.AddIngredient(ItemType<DivineEssence>(), 10);
            recipe.AddIngredient(ItemType<CataclysmEssence>(), 10);
            recipe.AddIngredient(ItemType<MagusCorePart>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
