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
    public class ExoticHeistedRunNGunSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedRunNGunSMG";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Exotic Heisted Run 'N' Gun SMG
             * 
             * Description: 
             * Exotic Weapon
             * 70% chance to not use ammo
             * Turns musket balls into high velocity bullets
             * Grants the holder the "Slapped Up" buff
             * "Hotwire's weapon of choice"
             * 
             * Obtain Point:
             * Post Yharon / Post Moon Lord
             *  
             * Intent:
             * This is intended to be a revolver that gives the user 2 buffs: Cheap Chlorophyte Bullets & The Hunter Buff
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("AuricBar", out ModItem Auric) && calamityMod.TryFind("CosmicAnvil", out ModTile CosmicAnvil))
            {
                Item.damage = 230;
                Item.sellPrice(gold: 30);
            }
            else
            {
                Item.damage = 27;
                Item.sellPrice(gold: 16);
            }

            Item.DamageType = ModContent.GetInstance<SubmachineGunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.rare = ModContent.RarityType<Exotic>(); //Exotic
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/CompactSMGShoot")
            {
                Volume = 0.7f,
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
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("AuricBar", out ModItem Auric) && calamityMod.TryFind("CosmicAnvil", out ModTile CosmicAnvil))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<CompactSMG>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(ModContent.ItemType<SlapJuice>(), 5);
                recipe.AddIngredient(Auric.Type, 5);
                recipe.AddTile(CosmicAnvil.Type);
                recipe.Register();
            }//Adds recipe if calamity mod is installed
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<CompactSMG>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(ModContent.ItemType<SlapJuice>(), 5);
                recipe.AddIngredient(ItemID.LunarBar, 12);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.7f;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.SlappedUp>(), 1);
        }
    }
}
