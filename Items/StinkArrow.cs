using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
    public class StinkArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stink Arrow");
            Tooltip.SetDefault("an Arrow that explodes into a cloud of stink gas upon impact"); // The item's description, can be set to whatever you want.

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 16; //Damage is weak as it is added to the musket ball projectile. the reason the musket ball projectile is used is so it is overlapped by bullet modifications
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(copper: 25);
            Item.rare = ItemRarityID.Lime;
            Item.shoot = ModContent.ProjectileType<Projectiles.StinkArrow>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(150);
            recipe.AddIngredient(ItemID.Stinkfish, 1);
            recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();


        }
    }
}
