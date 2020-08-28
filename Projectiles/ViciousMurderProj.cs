using Microsoft.Xna.Framework;
using Steamworks;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Stellarium.Projectiles
{
	public class ViciousMurderProj : ModProjectile
	{
		public float angleSpeed;

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.penetrate = 3;
			projectile.timeLeft = 300;
			projectile.tileCollide = true;
		}

		public override void SetStaticDefaults()
		{
			
		}
		public override void AI()
		{
			angleSpeed++;
			projectile.rotation += angleSpeed;
		}


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.Kill();
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Electric, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
			Player player = Main.player[(int)projectile.ai[0]];
			player.statLife += damage;
			player.HealEffect(damage, true);
		}
		
	}
}