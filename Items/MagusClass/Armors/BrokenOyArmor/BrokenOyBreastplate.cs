using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Armors.BrokenOyArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class BrokenOyBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("Increase maximum Satanism energy by 50");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
			modPlayer.MagusSataMax2 += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materials.OyIngot>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}