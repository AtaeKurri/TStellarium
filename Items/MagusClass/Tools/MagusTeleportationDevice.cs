using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.MagusClass.Tools
{
    class MagusTeleportationDevice : MagusClassDamageItem
    {
        float DestinationX, DestinationY;
        public bool PositionSetAlready;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleportation Device");
            Tooltip.SetDefault("'Every Magus must be able to teleport, so why not you ?'\n" +
                "Right click in inventory to reset position\n" +
                "Left click the first time to set position\n" +
                "And use left click again to teleport\n" +
                "Uses 50 units of every energies");
        }

        public override void SafeSetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 1;
            item.rare = ItemRarityID.LightRed;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 5;
            item.useAnimation = 5;
            item.consumable = false;

            MagusType = 3; // Toutes stats
            MagusAllStatCost = 50;
        }

        public override bool CanRightClick() { return true; }

        public override bool UseItem(Player player)
        {
            if (!PositionSetAlready) {
                DestinationX = player.position.X;
                DestinationY = player.position.Y;
                PositionSetAlready = true;
            }
            else if (PositionSetAlready)
            {
                Vector2 pos = new Vector2(DestinationX, DestinationY);
                player.Teleport(pos);
            }
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemType<MagusTeleportationDevice>());
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(mod, "Position", $"Destination set to x={DestinationX} y={DestinationY}. WIP"));
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                [nameof(DestinationX)] = DestinationX,
                [nameof(DestinationY)] = DestinationY,
                [nameof(PositionSetAlready)] = PositionSetAlready
            };
        }

        public override void Load(TagCompound tag)
        {
            DestinationX = tag.GetFloat(nameof(DestinationX));
            DestinationY = tag.GetFloat(nameof(DestinationY));
            PositionSetAlready = tag.GetBool(nameof(PositionSetAlready));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Materials.OyIngot>(), 10);
            recipe.AddIngredient(ItemType<Materials.MagusCore>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
