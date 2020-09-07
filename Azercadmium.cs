using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium
{
	public class Azercadmium : Mod
	{
		public Azercadmium()
		{
			
		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call(
					"AddBoss",
					0.85f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.Dirtball>() },
					this,
					"$Mods.Azercadmium.NPCName.Dirtball",
					(Func<bool>)(() => AzercadmiumWorld.downedDirtball),
					ModContent.ItemType<Items.Dirtball.CreepyMud>(),
					new List<int> { ModContent.ItemType<Items.Dirtball.BrokenDirtballCopperShortsword>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Dirtball.BrokenDirtballCopperShortsword>()}, //other
					$"Dirtball spawns rarely until it is defeated. It can also be manually summoned with a [i:{ModContent.ItemType<Items.Dirtball.CreepyMud>()}], which can be crafted or rarely dropped from enemies."
				);
				bossChecklist.Call(
					"AddBoss",
					1.95f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>() },
					this,
					"$Mods.Azercadmium.NPCName.AncientDesertDiscus",
					(Func<bool>)(() => AzercadmiumWorld.downedDiscus),
					ModContent.ItemType<Items.Discus.SuspiciousLookingDisc>(),
					new List<int> { ModContent.ItemType<Items.Discus.DriedEssence>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Discus.DriedEssence>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Discus.SuspiciousLookingDisc>()}]  to summon the discus leader in the desert night."
				);
				/*bossChecklist.Call(
					"AddBoss",
					3.05f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.ColossalCell>() },
					this,
					"$Mods.Azercadmium.NPCName.ColossalCell",
					(Func<bool>)(() => AzercadmiumWorld.downedCell),
					ModContent.ItemType<Items.Microbiome.CellularSnack>(),
					new List<int> { ModContent.ItemType<Items.Microbiome.Cytoplasm>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Microbiome.Cytoplasm>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Microbiome.CellularSnack>()}] in the microbiome."
				);*/
				bossChecklist.Call(
					"AddBoss",
					8.75f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.ComputerVirus>() },
					this,
					"$Mods.Azercadmium.NPCName.ComputerVirus",
					(Func<bool>)(() => AzercadmiumWorld.downedComVirus),
					ModContent.ItemType<Items.ComputerVirus.MechanicalDisc>(),
					new List<int> { ModContent.ItemType<Items.ComputerVirus.SoulOfByte>() }, //collectables
					new List<int> { ModContent.ItemType<Items.ComputerVirus.SoulOfByte>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.ComputerVirus.MechanicalDisc>()}]  to taunt the cyber plague."
				);
				bossChecklist.Call(
					"AddBoss",
					10.5f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.EmpressSlime>()},
					this,
					"$Mods.Azercadmium.NPCName.EmpressSlime",
					(Func<bool>)(() => AzercadmiumWorld.downedEmpress),
					ModContent.ItemType<Items.Empress.EmpressChalice>(),
					new List<int> { ModContent.ItemType<Items.Empress.EmpressShard>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Empress.EmpressShard>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Empress.EmpressChalice>()}]"
				);
				/*bossChecklist.Call(
					"AddBoss",
					14.5f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.AzercadmiumianMineralExtractor>()},
					this,
					"$Mods.Azercadmium.NPCName.AzercadmiumianMineralExtractor",
					(Func<bool>)(() => AzercadmiumWorld.downedMineral),
					ModContent.ItemType<Items.Mineral.GigaGemstone>(),
					new List<int> { ModContent.ItemType<Items.Mineral.GalacticDiamondium>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Mineral.GalacticDiamondium>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Mineral.GigaGemstone>()}] at night to send its scanners out of control."
				);
				bossChecklist.Call(
					"AddMiniBoss",
					14.75f,
					new List<int> { ModContent.NPCType<NPCs.Minibosses.XenicAcidpumper>() },
					this,
					"$Mods.Azercadmium.NPCName.XenicAcidpumper",
					(Func<bool>)(() => AzercadmiumWorld.downedXenic),
					ModContent.ItemType<Items.Xenic.TimeDistortingBattery>(),
					new List<int> { ModContent.ItemType<Items.Xenic.XenicCore>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Xenic.XenicCore>()}, //other
					$"The Xenic Acidpumper can rarely spawn in space post-Azercadmiumian Mineral Extractor or can also be summoned with a [i:{ModContent.ItemType<Items.Xenic.TimeDistortingBattery>()}]"
				);*/
			}
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Prehardmode Bar", new int[]
			{
			ItemID.CopperBar,
			ItemID.TinBar,
			ItemID.IronBar,
			ItemID.LeadBar,
			ItemID.SilverBar,
			ItemID.TungstenBar,
			ItemID.GoldBar,
			ItemID.PlatinumBar
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyPHBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
			{
			ItemID.Amethyst,
			ItemID.Topaz,
			ItemID.Sapphire,
			ItemID.Emerald,
			ItemID.Amber,
			ItemID.Diamond,
			ItemID.Ruby
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyGem", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Shadow Scale, Tissue Sample, or Cytoplasm", new int[]
			{
			ItemID.ShadowScale,
			ItemID.TissueSample,
			ItemType("Cytoplasm")
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyShadowScale", group);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.RecallPotion, 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddIngredient(null, "GlazedLens", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MagicMirror);
			recipe.AddRecipe();
			
			/*recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.PinkGel, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.ThornsPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.PinkGel, 4);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.CalmingPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater, 10);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(null, "DriedEssence", 10);
			recipe.AddIngredient(ItemID.PinkGel, 30);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.HeartreachPotion, 10);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.CobaltOre);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.AmmoReservationPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.PalladiumOre);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.InfernoPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.MythrilOre);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.RagePotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.OrichalcumOre);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.WrathPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater, 10);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(null, "DriedEssence", 10);
			recipe.AddIngredient(ItemID.AdamantiteOre, 10);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.LifeforcePotion, 10);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddIngredient(ItemID.Waterleaf);
			recipe.AddIngredient(null, "DriedEssence");
			recipe.AddIngredient(ItemID.TitaniumOre);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.EndurancePotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DemoniteBar, 7);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.StylistKilLaKillScissorsIWish);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimtaneBar, 7);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.StylistKilLaKillScissorsIWish);
			recipe.AddRecipe();*/
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.Spike, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.BreakerBlade);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.Pwnhammer);
			recipe.AddRecipe();
			
			/*recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 10);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(null, "GlazedLens");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 11);
			recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(null, "GlazedLens");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Arkhalis);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 9);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.AddIngredient(ItemID.Bone, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Muramasa);
			recipe.AddRecipe();*/
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.PocketMirror);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MechanicalWheelPiece);
			recipe.AddIngredient(ItemID.MechanicalWagonPiece);
			recipe.AddIngredient(null, "MechanicalGearPiece");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.MinecartMech);
			recipe.AddRecipe();
			
			/*recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 8);
			recipe.AddIngredient(null, "GlazedLens");
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedBoomerang);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "MagentiteBar", 16);
			recipe.AddIngredient(ItemID.Cloud, 12);
			recipe.AddIngredient(ItemID.FallenStar, 8);
			recipe.AddIngredient(ItemID.RainCloud, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Starfury);
			recipe.AddRecipe();*/
			
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofRegeneration);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldHelmet);
			recipe.AddIngredient(ItemID.Glass);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MiningHelmet);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldBar, 9);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Seashell);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Trident);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Azercadmium:AnyPHBar", 5);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SlimeCrown);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 4);
			recipe.AddIngredient(ItemID.Hook);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeHook);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 4);
			recipe.AddIngredient(ItemID.Leather, 2);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimySaddle);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 3);
			recipe.AddRecipeGroup("IronBar", 7);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeGun);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 3);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeStaff);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Cactus);
			recipe.AddIngredient(null, "BloodySpiderLeg");
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.ThornsPotion);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "Electrolight", 11);
			recipe.AddIngredient(ItemID.RainCloud, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.NimbusRod);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CopperPlatform", 2);
			recipe.SetResult(ItemID.CopperBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "TinPlatform", 2);
			recipe.SetResult(ItemID.TinBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "IronPlatform", 2);
			recipe.SetResult(ItemID.IronBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "LeadPlatform", 2);
			recipe.SetResult(ItemID.LeadBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SilverPlatform", 2);
			recipe.SetResult(ItemID.SilverBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "TungstenPlatform", 2);
			recipe.SetResult(ItemID.TungstenBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "AlternateGoldPlatform", 2);
			recipe.SetResult(ItemID.GoldBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "PlatinumPlatform", 2);
			recipe.SetResult(ItemID.PlatinumBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.EmptyBullet, 50);
			recipe.AddIngredient(null, "Electrolight");
			recipe.SetResult(ItemID.HighVelocityBullet, 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "GoldenShowerHidden");
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenShower);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.SnowBlock, 12);
			recipe.AddIngredient(null, "CryoCrystal", 9);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.HandWarmer);
			recipe.AddRecipe();
		}
		/*public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome && Main.LocalPlayer.ZoneRockLayerHeight)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/MicroUnder");
				priority = MusicPriority.BiomeHigh;
			}
			else if (Main.LocalPlayer.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Micro");
				priority = MusicPriority.BiomeHigh;
			}
		}*/
	}
}