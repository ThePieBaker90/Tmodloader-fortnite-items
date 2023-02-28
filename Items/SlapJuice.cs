using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class SlapJuice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slap Juice");
            Tooltip.SetDefault("Grants \"Slapped Up!\" buff\n\"Get Slapped Up with Slap Juice!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(229, 111, 0),
                new Color(229, 161, 0),
                new Color(229, 182, 0)
            };
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind<ModItem>("BloodOrb", out ModItem BloodOrb))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.BottledWater, 1);
                recipe.AddIngredient(BloodOrb.Type, 10);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }//Adds bloodorb recipe if calamity mod is installed

            Recipe recipe2 = CreateRecipe();
            recipe2.AddRecipeGroup(RecipeGroupID.Fruit, 2);
            recipe2.AddIngredient(ItemID.BottledHoney, 1);
            recipe2.AddIngredient(ItemID.Blinkroot, 1);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();



        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 120;
            Item.useTime = 120;
            Item.useTurn = true;
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Consumables/SlurpJuiceDrink")
            {
                Volume = 2f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green; //Post 
            Item.value = Item.buyPrice(silver: 50);

            Item.buffType = ModContent.BuffType<Buffs.SlappedUp>(); // Applies "Slapped Up"
            Item.buffTime = 36000; // Lasts 10 Minutes

        }
    }
}
