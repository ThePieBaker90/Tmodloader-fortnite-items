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
using FortniteItems.Content.Items.Weapons;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Items.Consumables;

namespace FortniteItems.Content.Items.GlobalItems
{
    public class BossBagLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if(item.type == ItemID.KingSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BurstSMG>(), 2));
            }

            if (item.type == ItemID.DeerclopsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RotatingGizmo>(), 1));
            }

            if (item.type == ItemID.GolemBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MammothPistol>(), 12));
            }

            if (item.type == ItemID.FishronBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<LMG>(), 3));
            }

            if (item.type == ItemID.MoonLordBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChugJug>(), 1, 10, 20));
            }

            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
                if (calamityMod == null)
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SixShooter>(), 2));
                }
            }
        }
    }
}
