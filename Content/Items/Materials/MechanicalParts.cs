﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Materials
{
    public class MechanicalParts : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/SleekMechanicalParts";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Sleek Mechanical Parts
             * 
             * Description: 
             * N/A
             * 
             * Obtain Point:
             * Obtained as a drop chance from frankenstein or fritz during the pre mech solar eclipse
             *  
             * Intent:
             * Used as a way to make sure the player has passed the pre mech solar eclipse
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Pink; //Solar eclipse drop
            Item.maxStack = 9999;
        }

    }
}
