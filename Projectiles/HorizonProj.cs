using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Projectiles
{
	public class HorizonProj : ModProjectile
	{
		public float angleSpeed = 0.03f;

		public override void SetDefaults()
		{
			projectile.width = 195;
			projectile.height = 195;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 10;
			projectile.timeLeft = 300;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{

		}

		public override void AI()
		{
			projectile.rotation += angleSpeed;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Electric, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}
    }
}