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
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.GlobalItems
{
    public class DamageClassBowGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            //List of all vanilla bows
            //Pre hardmode bows
            if (item.type == ItemID.WoodenBow)
            {
                return true;
            }
            else if (item.type == ItemID.BorealWoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.CopperBow)
            {
                return true;
            }
            else if (item.type == ItemID.PalmWoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.RichMahoganyBow)
            {
                return true;
            }
            else if (item.type == ItemID.TinBow)
            {
                return true;
            }
            else if (item.type == ItemID.EbonwoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.IronBow)
            {
                return true;
            }
            else if (item.type == ItemID.ShadewoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.LeadBow)
            {
                return true;
            }
            else if (item.type == ItemID.SilverBow)
            {
                return true;
            }
            else if (item.type == ItemID.TungstenBow)
            {
                return true;
            }
            else if (item.type == ItemID.AshWoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.GoldBow)
            {
                return true;
            }
            else if (item.type == ItemID.PlatinumBow)
            {
                return true;
            }
            else if (item.type == ItemID.DemonBow)
            {
                return true;
            }
            else if (item.type == ItemID.TendonBow)
            {
                return true;
            }
            else if (item.type == ItemID.BloodRainBow)
            {
                return true;
            }
            else if (item.type == ItemID.BeesKnees)
            {
                return true;
            }
            else if (item.type == ItemID.HellwingBow)
            {
                return true;
            }
            else if (item.type == ItemID.MoltenFury)
            {
                return true;
            }//hardmode bows
            else if (item.type == ItemID.PearlwoodBow)
            {
                return true;
            }
            else if (item.type == ItemID.Marrow)
            {
                return true;
            }
            else if (item.type == ItemID.IceBow)
            {
                return true;
            }
            else if (item.type == ItemID.DaedalusStormbow)
            {
                return true;
            }
            else if (item.type == ItemID.ShadowFlameBow)
            {
                return true;
            }
            else if (item.type == ItemID.CobaltRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.PalladiumRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.MythrilRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.OrichalcumRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.AdamantiteRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.TitaniumRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.HallowedRepeater)
            {
                return true;
            }
            else if (item.type == ItemID.ChlorophyteShotbow)
            {
                return true;
            }
            else if (item.type == ItemID.DD2PhoenixBow)//Phantom Phoenix
            {
                return true;
            }
            else if (item.type == ItemID.PulseBow)
            {
                return true;
            }
            else if (item.type == ItemID.StakeLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.DD2BetsyBow)//Aerial Bane
            {
                return true;
            }
            else if (item.type == ItemID.Tsunami)
            {
                return true;
            }
            else if (item.type == ItemID.FairyQueenRangedItem)//Eventide
            {
                return true;
            }
            else if (item.type == ItemID.Phantasm)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<BowClass>();
        }
    }
}
