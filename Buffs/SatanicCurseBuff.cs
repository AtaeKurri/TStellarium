using Stellarium.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace Stellarium.Buffs
{
    public class SatanicCurseBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Satanic Curse");
            Description.SetDefault("Losing Life");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StellariumPlayer>().SatanicCurseBuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StellariumGlobalNPC>().SatanicCurseBuff = true;
        }
    }
}