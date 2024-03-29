﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class SidewaysRifle : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/SidewaysRifle";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sideways Rifle");
            // Tooltip.SetDefault("Does not use ammo and shoots a bouncing laser\n\"Forged from Cube Monster Parts\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //gun that has infinite ammo
        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 65;
            Item.height = 40;
            Item.useTime = 52;
            Item.useAnimation = 52;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed; //Post Slime Queen
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SidewaysRifleShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.ShadowBeamFriendly;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.ArmorPenetration = 30;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ItemID.GelBalloon, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.CobaltBar, 10);
            recipe2.AddIngredient(ItemID.GelBalloon, 25);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
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

        }


    }
}
