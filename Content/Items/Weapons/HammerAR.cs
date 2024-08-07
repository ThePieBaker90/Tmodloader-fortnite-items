﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class HammerAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/HammerAR";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Hammer Assault Rifle
             * 
             * Description: 
             * 20% chance to not consume ammo
             * Turns musket balls into explosive bullets
             * "Drop the Hammer"
             * 
             * Obtain Point:
             * Pre Hardmode Requires atleast one trip to hell to get hellstone bricks from a ruined house.
             *  
             * Intent:
             * This is intended to be a post-cultist direct upgrade to the Pulse Rifle
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a pre-hardmode rifle alternative to the pheonix blaster
        public override void SetDefaults()
        {

            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.Orange; //made of hellstone
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/HammerARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 12;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 6;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddTile(TileID.Hellforge); //Hell forge
            recipe.Register();

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

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.ExplosiveBullet;
            }


            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2f));
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.2f;
        }

    }
}