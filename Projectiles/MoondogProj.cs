using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Projectiles
{
	public class MoondogProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moondog Proj");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 255;
			projectile.timeLeft = 600;
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			CreateDust();
		}

		public virtual void CreateDust()
		{
			Color color = Color.Red;
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GreenBlood, 0f, 0f, 0);
			Main.dust[dust].velocity *= 0.4f;
			Main.dust[dust].velocity += projectile.velocity;
		}
	}
}