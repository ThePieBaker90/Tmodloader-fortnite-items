﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Weapons
{
    public class ThermalDMR : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ThermalDMR";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bolt Action Sniper Rifle");
            // Tooltip.SetDefault("Turns musket balls into high velocity bullets\n\"Hit 'em where they can't reach you\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post EoC sniper rifle
        public override void SetDefaults()
        {

            Item.damage = 27;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Orange; //Post BEEEEEEEEEEEEEEEEEEEE craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DMRShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 30;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 25;
            Item.crit = 10;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Radar, 1);
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ModContent.ItemType<DMR>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }


        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
            player.AddBuff(BuffID.Hunter, 1);
        }

    }
}