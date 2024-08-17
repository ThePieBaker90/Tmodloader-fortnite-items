using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Materials
{
    public class SimpleMechanicalParts : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MissingTexture";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Simple Mechanical Parts
             * 
             * Description: 
             * N/A
             * 
             * Obtain Point:
             * TBD
             *  
             * Intent:
             * TBD
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }

        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Green; //Goblin Army Drop
            Item.maxStack = 9999;
        }

    }
}
