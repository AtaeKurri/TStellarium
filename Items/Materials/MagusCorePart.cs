using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Items.Materials
{
    class MagusCorePart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magus Core Part");
            Tooltip.SetDefault("'Seems like a part of something'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 99;
            item.rare = ItemRarityID.LightRed;
        }
    }
    public class MagusCorePartGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.hardMode)
            {
                if (npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.SkeletronHead || npc.type == NPCID.WallofFlesh ||
                    npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.TheDestroyer ||
                    npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Plantera || npc.type == NPCID.Golem ||
                    npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore)
                {
                    Item.NewItem(npc.getRect(), ItemType<MagusCorePart>(), 2);
                }
            }
        }
    }
}
