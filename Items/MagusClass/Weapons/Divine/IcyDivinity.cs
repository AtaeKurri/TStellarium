using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Divine
{
    public class IcyDivinity : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(44, 44);
            item.damage = 25 + MagusClassDamagePlayer.DivineDamageModifier();
            item.knockBack = 3;
            item.rare = ItemRarityID.Blue;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.shoot = ProjectileID.UFOLaser;
            item.shootSpeed = 8f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;

            MagusDivineCost = 5;
            MagusType = 1; // Divine
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.DivineEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}