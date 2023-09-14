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
    public class DamageClassAssaultGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            if(item.type == ItemID.Minishark)
            {
                return true;
            }
            else if(item.type == ItemID.ClockworkAssaultRifle){
                return true;
            }
            else if (item.type == ItemID.Gatligator)
            {
                return true;
            }
            else if (item.type == ItemID.CoinGun)
            {
                return true;
            }
            else if (item.type == ItemID.Megashark)
            {
                return true;
            }
            else if (item.type == ItemID.CandyCornRifle)
            {
                return true;
            }
            else if (item.type == ItemID.ChainGun)
            {
                return true;
            }
            else if (item.type == ItemID.VortexBeater)
            {
                return true;
            }
            else if (item.type == ItemID.SDMG)
            {
                return true;
            }
            else if (item.type == ItemID.DartRifle)
            {
                return true;
            }
            else if (item.type == ItemID.NailGun)
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
            item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
        }
    }
}
