using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Consumables
{
    public class HopRock : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/HopRock";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hop Rock");
            // Tooltip.SetDefault("Grants \"Otherworld Gravity\" buff\n\"Crystaline floatiness from another reality\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;


            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(65, 54, 152),
                new Color(76, 63, 172),
                new Color(126, 117, 204)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item4;
            Item.maxStack = 9999;
            Item.consumable = true;
            //Dropped by meteor heads
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 10);

            Item.buffType = ModContent.BuffType<Buffs.OtherworldlyGravity>(); // Applies "Shield 100" (40 Defense)
            Item.buffTime = 14400; // Lasts 8 Minutes

        }



    }
}
