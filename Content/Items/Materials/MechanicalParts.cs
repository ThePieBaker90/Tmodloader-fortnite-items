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
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MechanicalParts";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Parts");
            // Tooltip.SetDefault("Used to craft mechanical weapons");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(gold: 1);
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ModContent.RarityType<Exotic>(); //Wizard Buy
            Item.maxStack = 999;
        }

    }
}