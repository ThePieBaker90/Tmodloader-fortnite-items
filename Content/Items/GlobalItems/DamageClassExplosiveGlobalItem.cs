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
    public class DamageClassExplosiveGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            if (item.type == ItemID.GrenadeLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.ProximityMineLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.RocketLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.Stynger)
            {
                return true;
            }
            else if (item.type == ItemID.JackOLanternLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.SnowmanCannon)
            {
                return true;
            }
            else if (item.type == ItemID.FireworksLauncher)//Celebration 
            {
                return true;
            }
            else if (item.type == ItemID.ElectrosphereLauncher)
            {
                return true;
            }
            else if (item.type == ItemID.Celeb2)//Celebration MK2
            {
                return true;
            }
            else if (item.type == ItemID.Grenade)
            {
                return true;
            }
            else if (item.type == ItemID.StickyGrenade)
            {
                return true;
            }
            else if (item.type == ItemID.BouncyGrenade)
            {
                return true;
            }
            else if (item.type == ItemID.Beenade)
            {
                return true;
            }
            else if (item.type == ItemID.PartyGirlGrenade)//Happy Grenade
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
            item.DamageType = ModContent.GetInstance<ExplosiveClass>();
        }
    }
}
