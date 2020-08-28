using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Linq;
using Stellarium.Items.MagusClass.Accessories;

namespace Stellarium.Items.MagusClass
{
    public class MagusClassDamagePlayer : ModPlayer
    {
        public static MagusClassDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MagusClassDamagePlayer>();
        }

        // Player related

        public float MagusDamageAdd;
        public float MagusDamageMult = 1f;
        public float MagusKnockback;
        public int MagusCrit;
        public int Cata, Divine, Sata;

        // Accessories

        public bool BatteryPack;
        public bool EnergyThief;
        public bool EnergeticVampire;
        public bool EnergyFlash;

        // Damage Modifiers
        public static bool DivineShard { get; set; }
        public static bool BlessingOfTheDust { get; set; }
        public static bool FisicaWish { get; set; }
        public static bool MagusFlower { get; set; }

        // Cataclysmique
        public int MagusCataCurrent;
        public const int DefaultMagusCataMax = 100;
        public int MagusCataMax, MagusCataMax2;
        public float MagusCataRegenRate;
        internal int MagusCataRegenTimer = 0;
        public static readonly Color HealMagusCata = new Color(187, 91, 201);

        // Divine
        public int MagusDivineCurrent;
        public const int DefaultMagusDivineMax = 100;
        public int MagusDivineMax, MagusDivineMax2;
        public float MagusDivineRegenRate;
        internal int MagusDivineRegenTimer = 0;
        public static readonly Color HealMagusDivine = new Color(187, 91, 201);

        // Satanique
        public int MagusSataCurrent;
        public const int DefaultMagusSataMax = 100;
        public int MagusSataMax, MagusSataMax2;
        public float MagusSataRegenRate;
        internal int MagusSataRegenTimer = 0;
        public static readonly Color HealMagusSata = new Color(187, 91, 201);

        public override void Initialize()
        {
            MagusCataMax = DefaultMagusCataMax;
            MagusDivineMax = DefaultMagusDivineMax;
            MagusSataMax = DefaultMagusSataMax;
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
            MagusDamageAdd = 0f;
            MagusDamageMult = 1f;
            MagusKnockback = 0;
            MagusCrit = 0;
            MagusCataRegenRate = 1f;
            MagusDivineRegenRate = 1f;
            MagusSataRegenRate = 1f;
            MagusCataMax2 = MagusCataMax;
            MagusDivineMax2 = MagusDivineMax;
            MagusSataMax2 = MagusSataMax;
            DivineShard = false;
            BlessingOfTheDust = false;
            FisicaWish = false;
            MagusFlower = false;
            BatteryPack = false;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        public static int CataDamageModifier()
        {
            int dmg = 0;
            if (BlessingOfTheDust) { dmg -= 3; }
            if (MagusFlower) { dmg -= 3; }
            return dmg;
        }

        public static int DivineDamageModifier()
        {
            int dmg = 0;
            if (DivineShard) { dmg -= 5; }
            if (MagusFlower) { dmg -= 5; }
            return dmg;
        }

        public static int SataDamageModifier()
        {
            int dmg = 0;
            if(FisicaWish) { dmg -= 6; }
            if(MagusFlower) { dmg -= 6; }
            return dmg;
        }

        private void UpdateResource()
        {
            // Cata
            MagusCataRegenTimer++;

            if (MagusCataRegenTimer > 15 * MagusCataRegenRate)
            {
                MagusCataCurrent += 1;
                MagusCataRegenTimer = 0;
            }
            MagusCataCurrent = Utils.Clamp(MagusCataCurrent, 0, MagusCataMax2);

            // Divine
            MagusDivineRegenTimer++;

            if(MagusDivineRegenTimer > 15 * MagusDivineRegenRate)
            {
                MagusDivineCurrent += 1;
                MagusDivineRegenTimer = 0;
            }
            MagusDivineCurrent = Utils.Clamp(MagusDivineCurrent, 0, MagusDivineMax2);

            // Sata
            MagusSataRegenTimer++;

            if(MagusSataRegenTimer > 15 * MagusSataRegenRate)
            {
                MagusSataCurrent += 1;
                MagusSataRegenTimer = 0;
            }
            MagusSataCurrent = Utils.Clamp(MagusSataCurrent, 0, MagusSataMax2);
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            // Regen d'energie par les accessoires
            if (EnergyThief)
            {
                MagusCataCurrent += (damage >= 200) ? damage / 4 : damage / 2;
            }
            if (EnergeticVampire)
            {
                MagusSataCurrent += (damage >= 200) ? damage / 4 : damage / 2;
            }
            if (EnergyFlash)
            {
                MagusDivineCurrent += (damage >= 200) ? damage / 4 : damage / 2;
            }

            // Autre chose...
        }
    }
}