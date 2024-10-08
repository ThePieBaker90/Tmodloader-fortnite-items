﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class MakeshiftShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MakeshiftShotgun";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Makeshift Shotgun
             * 
             * Description: 
             * "Better than nothin'"
             * 
             * Obtain Point:
             * Pre Hardmode Craft
             *  
             * Intent:
             * A Pre boss shotgun which also functions as a material for other shotguns.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a basic post skeletron shotgun that hits hard 
        public override void SetDefaults()
        {

            Item.damage = 2;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue; //Early prehardmode crafted with demonite(or crimtane)
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MakeshiftShotgunShoot")
            {
                Volume = 0.5f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 5;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ebonwood, 15);
            recipe.AddRecipeGroup(nameof(ItemID.IronBar), 12);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Shadewood, 15);
            recipe2.AddRecipeGroup(nameof(ItemID.IronBar), 12);
            recipe2.AddIngredient(ItemID.CrimstoneBlock, 15);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {
            const int NumProjectiles = 4; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}