using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Stellarium.Items.MagusClass.Weapons.Divine
{
    class SacredMallet : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(30);
            item.damage = 47 + MagusClassDamagePlayer.SataDamageModifier();
            item.knockBack = 7;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.shoot = ProjectileType<Projectiles.SacredMalletProj>();
            item.shootSpeed = 14f;

            MagusDivineCost = 13;
            MagusType = 1; // Divine
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddIngredient(ItemID.CopperHammer);
            recipe.AddIngredient(ItemType<Materials.DivineEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.CopperHammer);
            recipe.AddIngredient(ItemType<Materials.DivineEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
