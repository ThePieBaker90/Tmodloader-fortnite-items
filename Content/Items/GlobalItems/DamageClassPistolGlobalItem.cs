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
    public class DamageClassPistolGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            if (item.type == ItemID.FlintlockPistol)
            {
                return true;
            }
            else if (item.type == ItemID.TheUndertaker)
            {
                return true;
            }
            else if (item.type == ItemID.Revolver)
            {
                return true;
            }
            else if (item.type == ItemID.Handgun)
            {
                return true;
            }
            else if (item.type == ItemID.PhoenixBlaster)
            {
                return true;
            }
            else if (item.type == ItemID.VenusMagnum)
            {
                return true;
            }
            else if (item.type == ItemID.FlareGun)
            {
                return true;
            }
            else if (item.type == ItemID.PainterPaintballGun)
            {
                return true;
            }
            else if (item.type == ItemID.DartPistol)
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
            item.DamageType = ModContent.GetInstance<PistolClass>();
        }
    }
}
