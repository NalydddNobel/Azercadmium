using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Corruption
{
	public class RoyalCorruptJavelance : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Stacks up to 3\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}
		public override void SetDefaults() {
			item.damage = 13;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.8f;
			item.value = Item.sellPrice(0, 0, 9, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RoyalCorruptJavelance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player){
			item.useTime = 34 + (item.stack * 10) - 10;
			item.useAnimation = 34 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.redJavelance)
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(18);
			if (numberProjectiles > 1) {
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}