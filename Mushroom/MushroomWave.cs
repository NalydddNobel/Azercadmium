using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Mushroom
{
	public class MushroomWave : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mushroom Wave");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 64;
			projectile.height = 64;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void AI() {
			/*for (int i = 0; i < 10; i++)
			{
				int dustType = 90;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}*/ //insert custom dust
		}
	}   
}