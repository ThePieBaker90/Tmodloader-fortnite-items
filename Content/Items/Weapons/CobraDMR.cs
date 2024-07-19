using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Content.Items.Materials;

namespace FortniteItems.Content.Items.Weapons
{
    public class CobraDMR : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/CobraDMR";

        public override void SetStaticDefaults()
        {
            /* Name: 
             * Cobra DMR
             * 
             * Description: 
             * A marksman rifle with a very fast rate of fire
             * "Strike like a nondescript snake"
             * 
             * Obtain Point:
             *  Post Deerclops Craft
             *  
             * Intent:
             *  medium damage, with medium knockback and a fast use time (for a DMR).
             *  Useful for sustained damage on distant enemies, less useful with groups or close enemies.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post deerclops DMR
        public override void SetDefaults()
        {

            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<MarksmanRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 11);
            Item.rare = ItemRarityID.Pink; //Post deerclops
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DMRShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 9;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 5;
            Item.crit = 10;

        }

        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RotatingGizmo>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DMR>(), 1);
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
        }

    }
}