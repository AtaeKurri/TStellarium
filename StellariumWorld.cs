using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Security.AccessControl;
using Terraria.GameContent.Generation;

namespace StellariumWorld
{
    public class StellariumWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Stellarium Ore Generation", OreGeneration));
            }
        }

        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "Generating Stellarium Ores!";
            for(var i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY);

                WorldGen.TileRunner(
                    x,
                    y,
                    (double)WorldGen.genRand.Next(4, 8),
                    WorldGen.genRand.Next(5, 9),
                    mod.TileType("OyOre"),
                    false,
                    0f,
                    0f,
                    false,
                    true
                );
            }
        }
    }
}