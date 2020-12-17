using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class EmpressShuriken : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Nuclei");
			Tooltip.SetDefault("Each nucleus can shoot poisonballs\nNuclei shake in random directions");
		}
		public override void SetDefaults() {
			item.damage = 69;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6.7f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("EmpressShuriken");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
	}
}