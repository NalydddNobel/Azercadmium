using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Buffs.Minions
{
	public class GlowingMushtop : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Glowing Mushtop");
			Description.SetDefault("The Glowing Mushtop will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.GlowingMushroom.GlowingMushtop>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}