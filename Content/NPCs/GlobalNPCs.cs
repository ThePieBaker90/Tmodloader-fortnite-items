﻿using Microsoft.Xna.Framework;
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
using FortniteItems.Content.Items.Consumables;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Items.Weapons;

namespace FortniteItems.Content.NPCs
{
    public class GlobalNPCs : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.ArmsDealer)
            {

                if (NPC.downedBoss3 == true)
                {
                    shop.Add<PumpShotgun>();
                }

                if (NPC.downedEmpressOfLight == true)
                {
                    shop.Add<MK7AR>();
                }

                if (Main.hardMode == true)
                {
                    shop.Add<HeavyShotgun>();
                }

                if (NPC.downedFishron == true)
                {
                    shop.Add<ChargeShotgun>();
                }

            }//if arms dealer

            if (shop.NpcType == NPCID.Merchant)
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<Flaregun>()) == true || Main.LocalPlayer.HasItem(ModContent.ItemType<FireworkFlaregun>()) == true)
                {
                    shop.GetEntry(ItemID.Flare);
                    shop.GetEntry(ItemID.BlueFlare);
                }
            }//if merchant

            if (shop.NpcType == NPCID.Demolitionist)
            {
                ModLoader.TryGetMod("SOTS", out Mod SOTS);

                if (NPC.downedBoss1 == true && SOTS == null)
                {
                    shop.Add<VGrenade>();
                }


            }//if demolitionist

            if (shop.NpcType == NPCID.GoblinTinkerer)
            {
                shop.Add<NutsnBolts>();


            }//if Goblin Tinkerer

            if (shop.NpcType == NPCID.Wizard)
            {
                shop.Add<ExoticEssence>();


            }//if Wizzzzzard
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.EyeofCthulhu) //Six Shooter drop from EoC if calamity is not installed
            {
                ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
                if (calamityMod == null)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SixShooter>(), 2));
                }

            }

            if (npc.type == NPCID.KingSlime) //Burst SMG Drop from King Slime
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BurstSMG>(), 2));
            }

            if (npc.type == NPCID.Frankenstein) //Mechanical Parts Drop from frankenstein
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechanicalParts>(), 10));
            }

            if (npc.type == NPCID.Fritz) //Mechanical Parts Drop from Fritz
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechanicalParts>(), 10));
            }

            if (npc.type == NPCID.Mimic) //Infantary Rifle drop from regular mimics
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfantaryRifle>(), 6));
            }

            if (npc.type == NPCID.IceMimic) //Infantary Rifle drop from ice mimics
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfantaryRifle>(), 3));
            }

            if (npc.type == NPCID.PirateCaptain) //Ranger Assault Rifle Drop from Pirate Captain
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
            }

            if (npc.type == NPCID.PirateCorsair) //Ranger Assault Rifle Drop from Pirate Corsair
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
            }

            if (npc.type == NPCID.PirateCrossbower) //Ranger Assault Rifle Drop from Pirate Crossbower
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
            }

            if (npc.type == NPCID.PirateDeadeye) //Ranger Assault Rifle Drop from Pirate Deadeye
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
            }

            if (npc.type == NPCID.PirateDeckhand) //Ranger Assault Rifle Drop from Pirate Deckhand
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
            }
            if (npc.type == NPCID.Mothron) //Heavy Assault Rifle Drop from Mothron
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeavyAR>(), 3));
            }
            if (npc.type == NPCID.PirateCaptain) //Combat Shotgun Drop from Pirate Captain
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.PirateCorsair) //Combat Shotgun Drop from Pirate Corsair
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.PirateCrossbower) //Combat Shotgun Drop from Pirate Crossbower
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.PirateDeadeye) //Combat Shotgun Drop from Pirate Deadeye
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.PirateDeckhand) //Combat Shotgun Drop from Pirate Deckhand
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.ElfCopter) //Charge SMG Drop from Elf Copter
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChargeSMG>(), 75));
            }

            if (npc.type == NPCID.ElfArcher) //Tactical AR Drop from Elf Archer
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TacticalAR>(), 75));
            }
            if (npc.type == NPCID.ZombieElf) //Tactical AR Drop from Elf Zombie
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TacticalAR>(), 75));
            }
            if (npc.type == NPCID.DukeFishron) //LMG drop from Duke fishron
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LMG>(), 5));
            }
            if (npc.type == NPCID.MoonLordCore) //Chug Jug Drop from Moon lord
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChugJug>(), 1, 5, 15));
            }
            if (npc.type == NPCID.MeteorHead) //Hop Rock Drop from Meteor Head
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HopRock>(), 2));
            }
        }//public override modifyNPCLoot
    }//public class
}//namespace