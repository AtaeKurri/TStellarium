using Microsoft.Xna.Framework;
using Stellarium.Items.MagusClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Armors.BrokenOyArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class BrokenOyHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increase maximum Cataclysmic energy by 50");
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
			modPlayer.MagusCataMax2 += 50;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<BrokenOyBreastplate>() && legs.type == ItemType<BrokenOyLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Decreases Magus energies time";
			MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
			modPlayer.MagusCataRegenRate -= 0.1f;
			modPlayer.MagusSataRegenRate -= 0.1f;
			modPlayer.MagusDivineRegenRate -= 0.1f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}