using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Consumables
{
    public class ChugJug : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ChugJug";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chug Jug");
            // Tooltip.SetDefault("Heals the User 400 Health\nGrants \"100% Shield\" buff\nHas a 15 second drink time but applies no potion sickness\n\"I really love to Chug Jug with you\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(47, 254, 198),
                new Color(59, 254, 237),
                new Color(59, 254, 254)
            };
        }


        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 900;
            Item.useTime = 900;
            Item.useTurn = true;
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Consumables/ChugJugDrink")
            {
                Volume = 0.3f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple; //Post Moonlord
            Item.value = Item.buyPrice(gold: 1);

            Item.buffType = ModContent.BuffType<Buffs.Shield100>(); // Applies "Shield 100" (40 Defense)
            Item.buffTime = 14400; // Lasts 8 Minutes

            Item.healLife = 400; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("BloodOrb", out ModItem BloodOrb))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.BottledWater, 1);
                recipe.AddIngredient(BloodOrb.Type, 60);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds bloodorb recipe if calamity mod is installed

        }
    }
}
