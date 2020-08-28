using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Stellarium.Items.MagusClass
{
    public abstract class MagusClassDamageItem : ModItem
    {
        public override bool CloneNewInstances => true;
        public int MagusCataCost = 0;
        public int MagusDivineCost = 0;
        public int MagusSataCost = 0;
        public int MagusType; // 0 = Cata, 1 = Divine, 2 = Sata, 3 = Toutes states
        // public static int CataCostModifier { get; set; }
        public int MagusAllStatCost = 0;

        public virtual void SafeSetDefaults()
        {

        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult)
        {
            add += MagusClassDamagePlayer.ModPlayer(player).MagusDamageAdd;
            mult *= MagusClassDamagePlayer.ModPlayer(player).MagusDamageMult;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += MagusClassDamagePlayer.ModPlayer(player).MagusKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += MagusClassDamagePlayer.ModPlayer(player).MagusCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " Magus " + damageWord;
            }

            if (MagusType == 0 && MagusCataCost > 0) // Cata
            {
                tooltips.Add(new TooltipLine(mod, "Cost", $"Uses {MagusCataCost} Cataclysmic Energy"));
            }
            else if (MagusType == 1 && MagusDivineCost > 0) // Divine
            {
                tooltips.Add(new TooltipLine(mod, "Cost", $"Uses {MagusDivineCost} Divine Energy"));
            }
            else if (MagusType == 2 && MagusSataCost > 0) // Sata
            {
                tooltips.Add(new TooltipLine(mod, "Cost", $"Uses {MagusSataCost} Satanic Energy"));
            }
        }

        public override bool CanUseItem(Player player)
        {
            var ClassDamagePlayer = player.GetModPlayer<MagusClassDamagePlayer>();

            if (MagusType == 0) // Cata
            {
                if (ClassDamagePlayer.MagusCataCurrent >= MagusCataCost)
                {
                    ClassDamagePlayer.MagusCataCurrent -= MagusCataCost;
                    return true;
                }
                return false;
            }
            else if (MagusType == 1) // Divine
            {
                if(ClassDamagePlayer.MagusDivineCurrent >= MagusDivineCost)
                {
                    ClassDamagePlayer.MagusDivineCurrent -= MagusDivineCost;
                    return true;
                }
                return false;
            }
            else if (MagusType == 2) // Sata
            {
                if (ClassDamagePlayer.MagusSataCurrent >= MagusSataCost)
                {
                    ClassDamagePlayer.MagusSataCurrent -= MagusSataCost;
                    return true;
                }
                return false;
            }
            else // Toutes stats
            {
                if(ClassDamagePlayer.MagusCataCurrent >= MagusAllStatCost &&
                    ClassDamagePlayer.MagusDivineCurrent >= MagusAllStatCost &&
                    ClassDamagePlayer.MagusSataCurrent >= MagusAllStatCost)
                {
                    ClassDamagePlayer.MagusCataCurrent -= MagusAllStatCost;
                    ClassDamagePlayer.MagusDivineCurrent -= MagusAllStatCost;
                    ClassDamagePlayer.MagusSataCurrent -= MagusAllStatCost;
                    return true;
                }
                return false;
            }
        }

        /*
        public static int MagusCostModifier()
        {
            int cost = 0;
            if (CataCostModifier >= 0)
            {

            }
            return cost;
        }
        */
    }
}