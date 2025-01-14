using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DiscusLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sandgrain Electroboots");
			Tooltip.SetDefault("Max run speed increased by 10%\nDamage increased by 2%\nImmune to desert winds");
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.maxRunSpeed += 0.10f;
			player.allDamage += 0.02f;
			player.buffImmune[194] = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 6);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}