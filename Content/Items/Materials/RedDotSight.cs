using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;
using FortniteItems.Content.Items.Weapons;

namespace FortniteItems.Content.Items.Materials
{
    public class RedDotSight : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MissingTexture";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Red Dot Sight
             * 
             * Description: 
             * A crafting material for modded weapons which are compatible with the red dot sight
             * 
             * Obtain Point:
             * TBD
             *  
             * Intent:
             * Decreases weapon spread on installed weapon
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(gold: 1);
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(ModContent.ItemType<RustyMechanicalParts>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}
