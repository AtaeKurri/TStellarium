using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Utilities;


namespace Stellarium.Items.MagusClass.Accessories
{
    class MagusFlower : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magus Flower");
            Tooltip.SetDefault("Increases Cataclysm, Divine and Satanism Magus Damage,\nmaximum stock and Regeneration Rate");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2, silver: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 6;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Warding, PrefixID.Armored });
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            MagusClassDamagePlayer.MagusFlower = true;
            modPlayer.MagusSataRegenRate -= 0.3f;
            modPlayer.MagusCataRegenRate -= 0.3f;
            modPlayer.MagusDivineRegenRate -= 0.3f;
            modPlayer.MagusSataMax2 += 50;
            modPlayer.MagusCataMax2 += 50;
            modPlayer.MagusDivineMax2 += 50;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<FisicaWish>());
            recipe.AddIngredient(ItemType<DivineShard>());
            recipe.AddIngredient(ItemType<BlessingOfTheDust>());
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>());
            recipe.AddIngredient(ItemType<Materials.DivineEssence>());
            recipe.AddIngredient(ItemType<Materials.SatanismEssence>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
