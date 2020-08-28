using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Stellarium.Items.MagusClass;
using Terraria.Utilities;
using Terraria.DataStructures;


namespace Stellarium.Items.MagusClass.Accessories
{
    class FisicaWish : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fisica's Wish");
            Tooltip.SetDefault("Increases Satanism Magus Damage, maximum stock and Regeneration Rate");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2, silver: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Warding, PrefixID.Armored });
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            MagusClassDamagePlayer.FisicaWish = true;
            modPlayer.MagusSataRegenRate -= 0.3f;
            modPlayer.MagusSataMax2 += 50;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 15);
            recipe.AddIngredient(ItemType<Materials.SatanismEssence>(), 5);
            recipe.AddIngredient(ItemID.Obsidian, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
