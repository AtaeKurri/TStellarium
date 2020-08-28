using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Cata
{
    public class SkyTouch : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(34, 34);
            item.damage = 30 + MagusClassDamagePlayer.CataDamageModifier();
            item.knockBack = 5;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.shoot = ProjectileType<Projectiles.SkyTouchProj>();
            item.shootSpeed = 5f;
            
            MagusCataCost = 8;
            MagusType = 0; // Cata
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 20);
            recipe.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}