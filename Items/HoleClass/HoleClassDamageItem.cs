using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Stellarium.Items.HoleClass
{
    public abstract class HoleClassDamageItem : ModItem
    {
        public override bool CloneNewInstances => true;
        public int HoleCost = 0;
        
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
            add += HoleClassDamagePlayer.ModPlayer(player).HoleDamageAdd;
            mult *= HoleClassDamagePlayer.ModPlayer(player).HoleDamageMult;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += HoleClassDamagePlayer.ModPlayer(player).HoleKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += HoleClassDamagePlayer.ModPlayer(player).HoleCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " Hole " + damageWord;
            }

            tooltips.Add(new TooltipLine(mod, "Cost", $"Uses {HoleCost} Hole Energy"));
        }

        public override bool CanUseItem(Player player)
        {
            var ClassDamagePlayer = player.GetModPlayer<HoleClassDamagePlayer>();

            if (ClassDamagePlayer.HoleEnergyCurrent >= HoleCost)
            {
                    ClassDamagePlayer.HoleEnergyCurrent -= HoleCost;
                    return true;
            }
            return false;
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