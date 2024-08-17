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
using FortniteItems.Content.Items.Consumables;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Items.Weapons;
using FortniteItems.Content.Items.Ammo;

namespace FortniteItems.Content.NPCs
{
    public class GlobalNPCs : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.ArmsDealer)
            {
                shop.Add<MK7AR>(Condition.DownedEmpressOfLight);
                shop.Add<HeavyShotgun>(Condition.Hardmode);
                shop.Add<ChargeShotgun>(Condition.DownedDukeFishron);
                shop.Add<PumpShotgun>(Condition.DownedSkeletron);
                shop.Add<DMR>();
                shop.Add<DoubleBarrelShotgun>(Condition.BloodMoon, Condition.Hardmode);
                
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

                if (SOTS == null)
                {
                    shop.Add<VGrenade>(Condition.DownedEyeOfCthulhu);
                }

                shop.Add<ExplosiveArrow>(Condition.DownedGolem);

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
            LeadingConditionRule NotExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            if (//Solar NPCS
                npc.type == NPCID.SolarDrakomireRider ||
                npc.type == NPCID.SolarDrakomire ||
                npc.type == NPCID.SolarSolenian ||
                npc.type == NPCID.SolarSpearman ||
                npc.type == NPCID.SolarCorite ||
                npc.type == NPCID.SolarSroller ||
                npc.type == NPCID.SolarCrawltipedeTail ||
                //Vortex NPCS
                npc.type == NPCID.VortexSoldier ||
                npc.type == NPCID.VortexHornetQueen ||
                npc.type == NPCID.VortexHornet ||
                npc.type == NPCID.VortexRifleman ||
                npc.type == NPCID.VortexLarva ||
                //Nebula NPCS
                npc.type == NPCID.NebulaBeast ||
                npc.type == NPCID.NebulaBrain ||
                npc.type == NPCID.NebulaHeadcrab ||
                npc.type == NPCID.NebulaSoldier ||
                //Stardust NPCS
                npc.type == NPCID.StardustCellBig ||
                npc.type == NPCID.StardustJellyfishBig ||
                npc.type == NPCID.StardustWormTail ||
                npc.type == NPCID.StardustSoldier ||
                npc.type == NPCID.StardustSpiderBig ||
                npc.type == NPCID.StardustSpiderSmall
                ) //Chrome Sample drop from all lunar events enemies
            {
                
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChromeSample>(), 30));
            }

            if (npc.type == NPCID.LunarTowerSolar ||
                npc.type == NPCID.LunarTowerVortex ||
                npc.type == NPCID.LunarTowerNebula ||
                npc.type == NPCID.LunarTowerStardust)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChromeSample>(), 1));
            }

            if (npc.type == NPCID.Deerclops) //Rotating Gizmo drop from Deerclops
            {
                //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RotatingGizmo>(), 1));

            }

            if (npc.type == NPCID.EyeofCthulhu) //Six Shooter drop from EoC if calamity is not installed
            {
                ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
                if (calamityMod == null)
                {
                    //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SixShooter>(), 2));
                }

            }

            if (npc.type == NPCID.MartianSaucerCore) //Compact SMG drop from martian saucer (core) if calamity is not installed
            {
                ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
                if (calamityMod == null)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CompactSMG>(), 3));
                }

            }

            if (npc.type == NPCID.BloodNautilus) //Dual Pistol drop from blood nautilus if calamity is not installed
            {
                ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
                if (calamityMod == null)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DualPistols>(), 2));
                }

            }

            if (npc.type == NPCID.KingSlime) //Burst SMG Drop from King Slime
            {
                //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BurstSMG>(), 2));
            }

            if (npc.type == NPCID.ScutlixRider ||
                npc.type == NPCID.MartianWalker ||
                npc.type == NPCID.MartianDrone ||
                npc.type == NPCID.GigaZapper ||
                npc.type == NPCID.MartianEngineer ||
                npc.type == NPCID.MartianOfficer ||
                npc.type == NPCID.RayGunner ||
                npc.type == NPCID.GrayGrunt ||
                npc.type == NPCID.BrainScrambler ||
                npc.type == NPCID.MartianSaucer
                ) //Alien Nanites Drop from Martian Madness Enemies
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlienNanites>(), 50));
            }

            if (npc.type == NPCID.GoblinPeon ||
                npc.type == NPCID.GoblinSorcerer ||
                npc.type == NPCID.GoblinThief ||
                npc.type == NPCID.GoblinWarrior ||
                npc.type == NPCID.GoblinArcher
                ) //Rusty Mechanical Parts Drop from Goblin Army Enemies
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustyMechanicalParts>(), 50));
            }

            if (npc.type == NPCID.Golem) //Mammoth Pistol Drop from golem
            {
                //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MammothPistol>(), 12));
            }

            if (npc.type == NPCID.Frankenstein ||
                npc.type == NPCID.Fritz) //Mechanical Parts Drop from frankenstein
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechanicalParts>(), 30));
            }

            if (npc.type == NPCID.Mimic) //Infantary Rifle drop from regular mimics
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfantaryRifle>(), 6));
            }

            if (npc.type == NPCID.IceMimic) //Infantary Rifle drop from ice mimics
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfantaryRifle>(), 3));
            }

            if (npc.type == NPCID.PirateCaptain ||
                npc.type == NPCID.PirateCorsair ||
                npc.type == NPCID.PirateCrossbower ||
                npc.type == NPCID.PirateDeadeye ||
                npc.type == NPCID.PirateDeckhand) //Ranger Assault Rifle Drop from all pirates
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RangerAR>(), 100));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CombatShotgun>(), 100));
            }

            if (npc.type == NPCID.Mothron) //Heavy Assault Rifle Drop from Mothron
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeavyAR>(), 3));
            }
            if (npc.type == NPCID.PirateCaptain) //Combat Shotgun Drop from Pirate Captain
            {
                
            }

            if (npc.type == NPCID.ElfCopter) //Charge SMG Drop from Elf Copter
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChargeSMG>(), 75));
            }

            if (npc.type == NPCID.ElfArcher ||
                npc.type == NPCID.ZombieElf) //Tactical AR Drop from Elf Archer / Zombie Elf
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TacticalAR>(), 75));
            }

            if (npc.type == NPCID.DukeFishron) //LMG drop from Duke fishron
            {
                //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<LMG>(), 3));
            }
            if (npc.type == NPCID.MoonLordCore) //Chug Jug Drop from Moon lord
            {
                //Adds to floor loot if the world isnt expert or above. For expert drops adjust the boss bag in Content/Items/GlobalItems/BossBagLoot.cs
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ChugJug>(), 1, 5, 15));
            }
            if (npc.type == NPCID.MeteorHead) //Hop Rock Drop from Meteor Head
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HopRock>(), 2));
            }
        }//public override modifyNPCLoot
    }//public class
}//namespace
