using Stellarium.NPCs;
using Terraria;
using Terraria.ModLoader;
using Stellarium.Items.MagusClass;

namespace Stellarium.Buffs
{
    public class PowerScrollBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Powering up!");
            Description.SetDefault("Magus damage increased");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MagusClassDamagePlayer modPlayer = MagusClassDamagePlayer.ModPlayer(player);
            modPlayer.MagusDamageMult *= 1.1f;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            
        }
    }
}