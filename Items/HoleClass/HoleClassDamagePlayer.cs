using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Linq;
using Stellarium.Items.MagusClass.Accessories;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.UI.Chat;
using System;

// TODO : Faire l'UI et les différents pouvoirs des Holes.

namespace Stellarium.Items.HoleClass
{
    public class HoleClassDamagePlayer : ModPlayer
    {
        public static HoleClassDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<HoleClassDamagePlayer>();
        }

        // Player related

        public float HoleDamageAdd;
        public float HoleDamageMult = 1f;
        public float HoleKnockback;
        public int HoleCrit;
        public int HoleEXP = 0;
        public int HoleLVL = 1;
        public int HoleEXPNeeded = 50;

        // Accessories

        

        // Energy
        public int HoleEnergyCurrent;
        public const int DefaultHoleEnergyMax = 100;
        public int HoleEnergyMax, HoleEnergyMax2;
        public float HoleEnergyRegenRate;
        internal int HoleEnergyRegenTimer = 0;
        public static readonly Color HealHoleEnergy = new Color(229, 0, 0);

        public override void Initialize()
        {
            HoleEnergyMax = DefaultHoleEnergyMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            HoleDamageAdd = 0f;
            HoleDamageMult = 1f;
            HoleKnockback = 0;
            HoleCrit = 0;
            HoleEnergyRegenRate = 1f;
            HoleEnergyMax2 = HoleEnergyMax;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        private void UpdateResource()
        {
            // Energy Regen
            HoleEnergyRegenTimer++;

            if (HoleEnergyRegenTimer > 10 * HoleEnergyRegenRate)
            {
                HoleEnergyCurrent += 1;
                HoleEnergyRegenTimer = 0;
            }
            HoleEnergyCurrent = Utils.Clamp(HoleEnergyCurrent, 0, HoleEnergyMax2);
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                [nameof(HoleEXP)] = HoleEXP,
                [nameof(HoleLVL)] = HoleLVL,
                [nameof(HoleEXPNeeded)] = HoleEXPNeeded
            };
        }

        public override void Load(TagCompound tag)
        {
            HoleEXP = tag.GetInt(nameof(HoleEXP));
            HoleLVL = tag.GetInt(nameof(HoleLVL));
            HoleEXPNeeded = tag.GetInt(nameof(HoleEXPNeeded));
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (!(Main.LocalPlayer.HeldItem.modItem is HoleClassDamageItem))
                return;

            HoleEXP += (int)damage / 4;
            LVLGain();
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (!(Main.LocalPlayer.HeldItem.modItem is HoleClassDamageItem))
                return;

            HoleEXP += (int)(damage / 4);
            LVLGain();
        }

        public void LVLGain()
        {
            if (HoleEXP >= HoleEXPNeeded)
            {
                HoleLVL += 1;
                HoleEXP -= HoleEXPNeeded;
                HoleEXPNeeded += 50;
                Main.NewText($"Hole Level Up! : LVL {HoleLVL}", 83, 75, 124);
            }
        }

        public void ResetAllMagus()
        {
            HoleLVL = 1;
            HoleEXP = 0;
            HoleEXPNeeded = 50;
            HoleEnergyMax2 = DefaultHoleEnergyMax;
        }
    }
}