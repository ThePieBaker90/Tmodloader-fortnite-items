﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Consumables;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHoprockDualies : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHoprockDualies";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Exotic Hoprock Dual Barrel Pistol
             * 
             * Description: 
             * Exotic Weapon
             * 33% chance to not use ammo
             * Gives the user the "Otherworldly Gravity" buff
             * "To space!!"
             * 
             * Obtain Point:
             * Post DoG / Moon-Lord
             *  
             * Intent:
             * This is intended to be a weapon which enhances late game mobilty of the user by increasing their flight speed.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post plague burst pistol
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null
                && calamityMod.TryFind("CosmiliteBar", out ModItem CosmiliteBar))
            {
                Item.damage = 600;
                Item.value = Item.sellPrice(gold: 28);
            }
            else
            {
                Item.damage = 130;
                Item.value = Item.sellPrice(gold: 28);
            }

            Item.DamageType = ModContent.GetInstance<PistolClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 5;
            Item.useAnimation = 10;
            Item.reuseDelay = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            
            Item.rare = ModContent.RarityType<Exotic>(); //Post DoG
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DualPistolsShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.crit = 21;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 7;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.consumeAmmoOnLastShotOnly = true;

        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null
                && calamityMod.TryFind("CosmiliteBar", out ModItem CosmiliteBar))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(CosmiliteBar.Type, 8);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(ModContent.ItemType<HopRock>(), 10);
                recipe.AddIngredient(ModContent.ItemType<DualPistols>(), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();

            }//adds calamity recipe
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 10);
                recipe.AddIngredient(ModContent.ItemType<DualPistols>(), 1);
                recipe.AddIngredient(ItemID.LunarBar, 12);
                recipe.AddIngredient(ItemID.FragmentVortex, 10);
                recipe.AddIngredient(ModContent.ItemType<HopRock>(), 10);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }

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


        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.33f;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.OtherworldlyGravity>(), 1);
        }
    }
}
