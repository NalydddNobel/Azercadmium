using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class LeafBloomer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Its bloom will be your doom!\nShoots venomous leaves that spawn flowers on impact");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 79;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2.2f;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RedCarnalliteLeaf");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LeadTunneler"));
			recipe.AddIngredient(mod.ItemType("RedCarnalliteBar"), 10);
			recipe.AddTile(TileID.Mythril);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}