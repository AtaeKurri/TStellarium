using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;


namespace Stellarium.Items.MagusClass.Accessories
{
    class MagusEmblem : MagusClassDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases all Magus damage by 15%\nIncreases Critical Chances of all Magus weapons\nDecrease Regeneration time");
        }

        public override void SafeSetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1, silver: 10);
            item.rare = ItemRarityID.LightRed;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            modPlayer.MagusDamageMult *= 1.15f;
            modPlayer.MagusCrit += 5;
            modPlayer.MagusCataRegenRate -= 0.3f;
            modPlayer.MagusDivineRegenRate -= 0.3f;
            modPlayer.MagusSataRegenRate -= 0.3f;
        }
    }
    public class SoulGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.WallofFlesh)
            {
                Item.NewItem(npc.getRect(), ItemType<MagusEmblem>());
            }
        }
    }
}
