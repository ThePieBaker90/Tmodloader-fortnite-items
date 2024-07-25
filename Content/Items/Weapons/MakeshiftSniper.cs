using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class MakeshiftSniper : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MakeshiftSniper";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Makeshift Sniper Rifle
             * 
             * Description: 
             * "More of a material than a weapon"
             * 
             * Obtain Point:
             * Pre Hardmode Craft
             *  
             * Intent:
             * A Pre boss sniper rifle which also functions as a material for other sniper rifles.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 26;
            Item.DamageType = ModContent.GetInstance<SniperRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 90;
            Item.useAnimation = 90;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10, silver: 50);
            Item.rare = ItemRarityID.Lime; //Post Plantera Sniper Rifle Crafted with Shroomite
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BoltActionSniperShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 6;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ebonwood, 15);
            recipe.AddRecipeGroup(nameof(ItemID.IronBar), 12);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Shadewood, 15);
            recipe2.AddRecipeGroup(nameof(ItemID.IronBar), 12);
            recipe2.AddIngredient(ItemID.CrimstoneBlock, 15);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15f, 0);
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