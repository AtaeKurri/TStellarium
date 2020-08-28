using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Weapons.Cata
{
    public class IcyCataclysm : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.Size = new Vector2(48, 48);
            item.damage = 25 + MagusClassDamagePlayer.CataDamageModifier();
            item.knockBack = 3;
            item.rare = ItemRarityID.Blue;
            item.mana = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = false;
            item.shoot = ProjectileType<Projectiles.IcyCataclysmProj>();
            item.shootSpeed = 1.5f;
            item.useTime = 15;
            item.useAnimation = 15;
            item.UseSound = SoundID.Item20;
            item.maxStack = 1;

            MagusCataCost = 5;
            MagusType = 0; // Cata
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.CataclysmEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}