﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class EvoChromeAR5 : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/EvoChromeAR5";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("EvoChrome Assault Rifle MKV");
            // Tooltip.SetDefault("Shoots in a 6 bullet burst\n\"Chrome Runs Rampant\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Intended to be a lunar events gun that is upgraded throughout the event
        public override void SetDefaults()
        {

            Item.damage = 64;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 3, silver: 60);
            Item.rare = ItemRarityID.Red; //Lunar Events
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MK5EvoChromeBurstShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 70;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 30;
            Item.reuseDelay = 10;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ModContent.ItemType<EvoChromeAR4>());
            recipe.AddTile(TileID.LunarCraftingStation);
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(0.125f)); //Random Bullet Spread


        }


    }
}