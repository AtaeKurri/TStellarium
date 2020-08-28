using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Utilities;


namespace Stellarium.Items.MagusClass.Accessories
{
    class EnergyThief : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Being hit by an ennemy regenerates Cataclysm energy");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Green;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Warding, PrefixID.Armored });
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            modPlayer.EnergyThief = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>(), 10);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
