using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.OtherJavelances
{
	public class Fleshleech : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Slowly leeches life\nStacks up to 4\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 31;
			item.ranged = true;
			item.width = 52;
			item.height = 52;
			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.8f;
			item.value = 20000;
			item.rare = ItemRarityID.LightRed;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Fleshleech");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.maxStack = 4;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 42 + (item.stack * 10) - 10;
			item.useAnimation = 42 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.redJavelance)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			}
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

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LeecherJavelance"));
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"));
			recipe.AddIngredient(mod.ItemType("VinepowerJavelance"));
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LeecherJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("VinepowerJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"), 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}