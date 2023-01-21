using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class MechanicalParts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Parts");
            Tooltip.SetDefault("Used to craft mechanical weapons");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Pink; //Solar eclipse drop
            Item.maxStack = 999;
        }

    }
}
