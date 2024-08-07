﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Projectiles;
using Terraria.DataStructures;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticDub : ModItem
    {
        int shotsFired = 1;
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticTheDub";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Exotic Dub
             * 
             * Description: 
             * TBD
             * 
             * Obtain Point:
             * TBD (somewhere early in hardmode due to the mobility it will provide, we dont want this mobility to be outclassed or to outclass wings, we want it to be a supplementary to low level wings.)
             *  
             * Intent:
             * TBD
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 20f;
            Item.value = Item.sellPrice(gold: 5);
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ModContent.RarityType<Exotic>(); 
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DoubleBarrelShotgunShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 8;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        /*
        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("CryonicBar", out ModItem CryonicBar))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(CryonicBar.Type, 8);
                recipe.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }//Adds calamity recipe if calamity is... installed
            else
            {
                //Sold by arms dealer during hardmode bloodmoon
            }
        }
        */


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
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
            if (shotsFired >= 1)
            {
                Item.reuseDelay = 114;
                shotsFired = 0;
                Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DoubleBarrelShotgunReload")
                {
                    Volume = 0.6f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
            }
            else if (shotsFired <= 0)
            {
                shotsFired++;
                Item.reuseDelay = 0;
                Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DoubleBarrelShotgunShoot")
                {
                    Volume = 0.6f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
            }

            const int NumProjectiles = 6; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}