using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.HoleClass.Weapons
{
    public class Horizon : HoleClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(48, 48);
            item.damage = 25;
            item.knockBack = 3;
            item.rare = ItemRarityID.Blue;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.HorizonProj>();
            item.shootSpeed = 5f;
            item.useTime = 40;
            item.useAnimation = 40;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.crit = 10;

            HoleCost = 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.OyCrystal>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}