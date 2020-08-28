using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Divine
{
    public class PutridHand : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(22, 22);
            item.damage = 40 + MagusClassDamagePlayer.CataDamageModifier();
            item.knockBack = 5;
            item.rare = ItemRarityID.Orange;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;
            item.shoot = ProjectileType<Projectiles.PutridHandProj>();
            item.shootSpeed = 15f;

            MagusDivineCost = 10;
            MagusType = 1; // Divine
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}