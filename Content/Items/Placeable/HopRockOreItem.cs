using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using FortniteItems.Content.Items.Consumables;
using FortniteItems.Content.Tiles;

namespace FortniteItems.Content.Items.Placeable
{
    public class HopRockOreItem : ModItem
    {
        //TODO change texture to obsidian tileset with altered colors
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hop Rock Chunk");
            // Tooltip.SetDefault("A Chunk of Hop Rocks");
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<HopRockOreTile>();
            Item.width = 12;
            Item.height = 12;
            Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddIngredient(ModContent.ItemType<HopRock>(), 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();

        }
    }
}