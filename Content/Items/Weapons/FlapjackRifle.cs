﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class FlapjackRifle : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FlapjackRifle";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Flapjack Rifle
             * 
             * Description: 
             * 50% chance not to consume ammo
             * A rifle with a spinning magazine and a fast fire rate
             * "Make heads turn"
             * 
             * Obtain Point:
             * Hardmode Tier 2 Metals
             *  
             * Intent:
             * An early hardmode minigun and a use for turtle shells for ranged players.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a hardmode minigun equivalent
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.3f;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Lime; //Post wall buy from Arms Dealer in jungle
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/FlapjackRifleShoot")
            {
                Volume = 0.8f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.TurtleShell, 1);
            recipe2.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe2.AddIngredient(ModContent.ItemType<MakeshiftAR>());
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6f)); //Random Bullet Spread

        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;

        }
    }
}