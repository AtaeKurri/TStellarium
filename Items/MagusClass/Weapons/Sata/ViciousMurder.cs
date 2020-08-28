using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Stellarium.Items.MagusClass.Weapons.Sata
{
    class ViciousMurder : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Steals the life of the target");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(30);
            item.damage = 36 + MagusClassDamagePlayer.SataDamageModifier();
            item.knockBack = 4;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.shoot = ProjectileType<Projectiles.ViciousMurderProj>();
            item.shootSpeed = 10f;

            MagusSataCost = 10;
            MagusType = 2; // Sata
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemType<Materials.SatanismEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
