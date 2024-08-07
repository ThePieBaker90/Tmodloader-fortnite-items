﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class BoltActionSniper : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/BoltActionSniper";

        public override void SetStaticDefaults()
        {
            /* Name: 
             *  Bolt Action Sniper Rifle
             * 
             * Description: 
             *  Turns musket balls into high velocity bullets
             *  "Hit 'em where they can't reach you"
             * 
             * Obtain Point:
             *  Post EoC Craft
             *  
             * Intent:
             *  a high damage, high knockback, but high use time sniper rifle.
             *  useful for hitting groups up to 3 and for those confident in their aim.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post EoC sniper rifle
        public override void SetDefaults()
        {

            Item.damage = 80;
            Item.DamageType = ModContent.GetInstance<SniperRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 90;
            Item.useAnimation = 90;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue; //Post EoC Craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BoltActionSniperShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 10;
            Item.crit = 10;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftSniper>());
            recipe.AddIngredient(ItemID.Lens, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.AddDecraftCondition(Condition.CrimsonWorld);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.DemoniteBar, 10);
            recipe2.AddIngredient(ModContent.ItemType<MakeshiftSniper>());
            recipe2.AddIngredient(ItemID.Lens, 10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddDecraftCondition(Condition.CorruptWorld);
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


            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }


        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}