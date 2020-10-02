using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Jungle
{
	public class MagicalVaccine : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Scares the heck outta those flat-earthers\nImmunity to feral bite");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[148] = true;
		}
	}
}