using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Materials
{
    public class RustyMechanicalParts : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/RustyMechanicalParts";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Rusty Mechanical Parts
             * 
             * Description: 
             * N/A
             * 
             * Obtain Point:
             * Obtained as a drop chance from any goblin in the goblin army
             *  
             * Intent:
             * Used as a way to make sure the player has passed the goblin army event
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
