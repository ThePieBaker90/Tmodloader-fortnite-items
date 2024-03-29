﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Content.Items.Ammo
{
    public class FlameArrow : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FlameArrow";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primal Flame Arrow");
            // Tooltip.SetDefault("A glass headed arrow filled with alchohol which ignites upon impact"); // The item's description, can be set to whatever you want.

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(copper: 2);
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<Projectiles.FlameArrow>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(150);
            recipe.AddIngredient(ItemID.Ale, 5);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.WoodenArrow, 150);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();


        }
    }
}
