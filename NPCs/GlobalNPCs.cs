using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using FortniteItems.Items;


namespace FortniteItems.NPCs
{
	public class ExampleGlobalNPC : GlobalNPC
	{

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer)
			{
				if (NPC.downedBoss3 == true)
					shop.item[nextSlot++].SetDefaults(ModContent.ItemType<PumpShotgun>(), false);

				if (Main.hardMode == true)
					shop.item[nextSlot++].SetDefaults(ModContent.ItemType<HeavyShotgun>(), false);
			}

			if (type == NPCID.Demolitionist == true)
            {
				if (NPC.downedBoss1 == true)
					shop.item[nextSlot++].SetDefaults(ModContent.ItemType<VGrenade>(), false);

            }
		}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			
			if (npc.type == NPCID.Pixie)
			{
				
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 80));
			}

			if (npc.type == NPCID.ManEater)
				{

					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BurstSMG>(), 100));

				}
			if (npc.type == NPCID.Snatcher)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BurstSMG>(), 100));

			}

			if (npc.type == NPCID.AngryTrapper)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BurstSMG>(), 40));

			}

			if (npc.type == NPCID.Lihzahrd)
			{
				if (NPC.downedPlantBoss == true)
				{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChargeSMG>(), 60));
				}
			}

		}
	}
}