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
    public class DamageClassMarksmanGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            if (item.type == ItemID.RedRyder)
            {
                return true;
            }
            else if (item.type == ItemID.Musket)
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
            item.DamageType = ModContent.GetInstance<MarksmanRifleClass>();
        }
    }
}
