using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Materials
{
    public class NutsnBolts : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/NutsnBolts";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nuts 'n' Bolts");
            // Tooltip.SetDefault("Can be crafted with of certain weapons to modify the texture and/or stats\nModified weapons can be reverted to its original state with these");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        //a material for modifying weapons
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 5);
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
        }

    }
}
