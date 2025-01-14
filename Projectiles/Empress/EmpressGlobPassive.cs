using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Empress
{
	public class EmpressGlobPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Glob");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void AI() {
			for (int i = 0; i < 10; i++) {
				int dustType = 183;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}