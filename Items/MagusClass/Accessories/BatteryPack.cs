using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Utilities;


namespace Stellarium.Items.MagusClass.Accessories
{
    class BatteryPack : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battery Pack");
            Tooltip.SetDefault("Increases all Magus maximum energy by 100.");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(silver: 3, copper: 60);
            item.rare = ItemRarityID.Blue;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Warding, PrefixID.Armored });
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            modPlayer.BatteryPack = true;
            modPlayer.MagusSataMax2 += 100;
            modPlayer.MagusCataMax2 += 100;
            modPlayer.MagusDivineMax2 += 100;
        }
    }
    public class BatteryPackGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.SkeletronHead)
            {
                if (Main.rand.NextBool(5))
                {
                    Item.NewItem(npc.getRect(), ItemType<BatteryPack>());
                }
            }
        }
    }
}
