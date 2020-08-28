using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Stellarium.Tiles
{
    public class OyOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;

            drop = mod.ItemType("OyCrystal");
            dustType = DustID.Platinum;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Oy Ore");
            AddMapEntry(new Color(100, 150, 200), name);

            minPick = 60;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.75f;
            b = 1f;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
