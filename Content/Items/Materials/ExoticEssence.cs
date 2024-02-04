using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Materials
{
    public class ExoticEssence : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticEssence";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Essence");
            // Tooltip.SetDefault("Used to craft exotic weapons");

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
            Item.maxStack = 9999;
        }

    }
}
