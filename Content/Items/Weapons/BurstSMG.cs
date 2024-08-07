﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class BurstSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/BurstSMG";
        public override void SetStaticDefaults()
        {
            /* Name: 
             *  Burst Submachine Gun
             * 
             * Description: 
             *  75% chance to not consume ammo
             *  Shoots in bursts of 4
             *  "The Future is Yours"
             * 
             * Obtain Point:
             *  King Slime Drop
             *  
             * Intent:
             *  This is intended to be an early game version of the UZI with a 4 shot burst
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Intended to be an early game smg
        public override void SetDefaults()
        {

            Item.damage = 2;
            Item.DamageType = ModContent.GetInstance<SubmachineGunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 4;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Orange; //Pre Hardmode King Slime
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BurstSMGShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.reuseDelay = 14;
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


            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9)); //Random Bullet Spread
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.75f;
        }


    }
}