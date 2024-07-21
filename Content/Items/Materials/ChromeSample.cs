using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Materials
{
    public class ChromeSample : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/Chrome";
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }

        //a martian madness crafting material
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan; //Lunar Events Drop
            Item.maxStack = 9999;
        }

    }
}
