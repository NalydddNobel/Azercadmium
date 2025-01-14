using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Wood
{
	public class WoodenSplinter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Stacks up to 2\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}
		public override void SetDefaults() {
			item.damage = 6;
			item.ranged = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.3f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.White;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("WoodenSplinter");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 2;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player) {
			item.useTime = 32 + (item.stack * 10) - 10;
			item.useAnimation = 32 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.redJavelance)
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(18);
			if (numberProjectiles > 1)
			{
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}