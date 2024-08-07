﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class FireworkFlaregun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FireworkFlaregun";

        public override void SetStaticDefaults()
        {
            /* Name: 
             * Firework Flaregun
             * 
             * Description: 
             * "Take them out with style"
             * 
             * Obtain Point:
             * Post Queen Slime
             *  
             * Intent:
             * This is intended to be a post-cultist direct upgrade to the Pulse Rifle
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a queen slime flare gun for crowd control
        public override void SetDefaults()
        {

            Item.damage = 60;
            Item.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.LightRed; //Queen Slime
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/FlareGunShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 15;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Flare;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ConfettiGun, 1);
            recipe.AddIngredient(ModContent.ItemType<Flaregun>());
            recipe.AddIngredient(ItemID.GelBalloon, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }

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

            if (type == ProjectileID.Flare)
            {
                type = ProjectileID.RocketFireworkRed;
            }

            if (type == ProjectileID.BlueFlare)
            {
                type = ProjectileID.RocketFireworkBlue;
            }

            if (type == ProjectileID.SpelunkerFlare)
            {
                type = ProjectileID.RocketFireworkYellow;
            }

            if (type == ProjectileID.CursedFlare)
            {
                type = ProjectileID.RocketFireworkGreen;
            }

        }
    }
}
