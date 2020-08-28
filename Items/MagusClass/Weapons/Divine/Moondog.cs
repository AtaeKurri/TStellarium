using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Divine
{
    public class Moondog : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(28, 30);
            item.damage = 35 + MagusClassDamagePlayer.DivineDamageModifier();
            item.knockBack = 3;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.MoondogProj>();
            item.shootSpeed = 10f;
            item.useTime = 8;
            item.useAnimation = 8;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;

            MagusDivineCost = 7;
            MagusType = 1; // Divine
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 20);
            recipe.AddIngredient(ItemID.MeteoriteBar, 3);
            recipe.AddIngredient(ItemType<Materials.DivineEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}