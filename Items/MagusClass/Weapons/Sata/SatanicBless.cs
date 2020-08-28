using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Sata
{
    public class SatanicBless : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(42, 42);
            item.damage = 10 + MagusClassDamagePlayer.SataDamageModifier();
            item.knockBack = 3;
            item.rare = ItemRarityID.Blue;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.SatanicBlessProj>();
            item.shootSpeed = 10f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;

            MagusSataCost = 5;
            MagusType = 2; // Sata
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.SatanismEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}