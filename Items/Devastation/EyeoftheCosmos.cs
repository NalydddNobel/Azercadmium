using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Azercadmium.Items.Devastation
{
	public class EyeoftheCosmos : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye of the Cosmos");
			Tooltip.SetDefault("Used to activate and deactivate Devastation Mode\nDevastation mode heavily increases the difficulty of the game and is not recommended for a first playthrough\nNote: Heavily unfinished\nCan only be activated in Expert Mode and when no bosses are alive\nDevastation mode only items will have the Mint Chocolate rarity\nCheck the Azercadmium Discord Server in #info for full list of changes\nDue to an odd glitch, after fighting a boss, you may or may not have to reload your world to change the difficulty again");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.value = 0;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = false;
		}
		public bool BossAlive() {
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead) {
					return true;
				}
            }
			return false;
        }
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
					if (Main.GameUpdateCount % 240 < 120)
                    tooltipLine.overrideColor = new Color((int)(146 - (int)(Main.GameUpdateCount % 120) * 0.40832f), (int)(255 - (int)((Main.GameUpdateCount % 120) * 1.65832f)), (int)(138 - (int)((Main.GameUpdateCount % 120) * 1.066f)));
					else
					tooltipLine.overrideColor = new Color((int)(97 + (int)(Main.GameUpdateCount % 120) * 0.40832f), (int)(56 + (int)((Main.GameUpdateCount % 120) * 1.65832f)), (int)(10 + (int)((Main.GameUpdateCount % 120) * 1.066f)));
					//146, 255, 138 and 97, 56, 10
                }
            }
        }
		public override bool CanUseItem(Player player) {
			return !BossAlive() && Main.expertMode;
		}
		public override bool UseItem(Player player) {
			AzercadmiumWorld.devastation = !AzercadmiumWorld.devastation;
			Main.PlaySound(SoundID.Roar, player.position, 0);
			if (AzercadmiumWorld.devastation == true) {
				Color messageColor = Color.LightGreen;
				string chat = "Devastation Mode activated! Prepare for pain (and mint)!";
				if (Main.netMode == NetmodeID.Server)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				else if (Main.netMode == NetmodeID.SinglePlayer)
					Main.NewText(Language.GetTextValue(chat), messageColor);
			}
			if (AzercadmiumWorld.devastation == false) {
				Color messageColor = Color.Maroon;
				string chat = "Devastation Mode deactivated! Too easy?";
				if (Main.netMode == NetmodeID.Server)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				else if (Main.netMode == NetmodeID.SinglePlayer)
					Main.NewText(Language.GetTextValue(chat), messageColor);
			}
			return true;
		}
	}
}