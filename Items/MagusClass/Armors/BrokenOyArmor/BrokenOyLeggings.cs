using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Stellarium.Items.MagusClass.Armors.BrokenOyArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BrokenOyLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increase maximum Divine energy by 50");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
			modPlayer.MagusDivineMax2 += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materials.OyIngot>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}