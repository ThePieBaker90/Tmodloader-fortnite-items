﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;

namespace FortniteItems.Content.Items.Weapons
{
    public class MechanicalBow : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MechanicalBow";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Bow");
            // Tooltip.SetDefault("Shoots arrows at a high velocity\n\"How Mechanical!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            Item.damage = 95;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Pink; //Post Solar
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 28;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MechanicalParts>(), 5);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftBow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

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
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}