﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using FortniteItems.Content.Projectiles;
using FortniteItems.Content.Items.Weapons;

namespace FortniteItems.Content.Items.Consumables
{
    public class KineticBoomerang : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/KineticBoomerang";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Kinetic Boomerang
             * 
             * Description: 
             * A boomerang with strong knockback and high speed
             * "a necessity to explore the wilds"
             * 
             * Obtain Point:
             * Post Solar Pillar
             *  
             * Intent:
             * This is intended to be a late game boomerang
             */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 200;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 20f;
            Item.value = Item.sellPrice(gold: 12);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
            Item.shootSpeed = 30;
            Item.noMelee = true;
            Item.ArmorPenetration = 25;
            Item.crit = 16;
            Item.shoot = ModContent.ProjectileType<Projectiles.KineticBoomerangProjectile>();
            Item.noUseGraphic = true;
        }

        //Checks if the player already has a boomerang out.
        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 12);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 20);
            recipe.AddIngredient(ItemID.LargeAmethyst, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // NewProjectile returns the index of the projectile it creates in the NewProjectile array.
            // Here we are using it to gain access to the projectile object.
            int projectileID = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            Projectile projectile = Main.projectile[projectileID];

            GlobalProjectileModification globalProjectile = projectile.GetGlobalProjectile<GlobalProjectileModification>();
            // For more context, see ExampleProjectileModifications.cs
            globalProjectile.SetTrail(Color.Purple);

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }


    }
}
