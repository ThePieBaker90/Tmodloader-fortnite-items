﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticNightHawk : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticNightHawk";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Night Hawk");
            // Tooltip.SetDefault("Exotic Weapon\nTurns musket balls into chlorophyte bullets\n20% chance to not consume ammo\n\"Mancake's Weapon of Choice\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            Item.damage = 300;
            //needs a buff when calamity comes out
            Item.DamageType = ModContent.GetInstance<PistolClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(gold: 24);
            Item.rare = ModContent.RarityType<Exotic>(); //Post Signus
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ScopedRevolverShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 15;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 60;
            Item.crit = 16;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("TwistingNether", out ModItem TwistingNether))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<ScopedRevolver>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(TwistingNether.Type, 1);
                recipe.AddIngredient(ItemID.LunarBar, 10);
                recipe.AddIngredient(ItemID.SoulofSight, 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds bloodorb recipe if calamity mod is installed
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<ScopedRevolver>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(ItemID.LunarBar, 10);
                recipe.AddIngredient(ItemID.SoulofSight, 5);
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

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.ChlorophyteBullet;
            }
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.2f;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
            player.AddBuff(BuffID.Hunter, 1);
        }

    }
}