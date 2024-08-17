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
    public class LeverActionRifle : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/LeverActionRifle";

        public override void SetStaticDefaults()
        {
            /* Name: 
             * Lever Action Rifle
             * 
             * Description: 
             * "Not to be confused with a button action rifle"
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

            Item.damage = 39;
            Item.DamageType = ModContent.GetInstance<SniperRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.buyPrice(gold: 10);
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.Green; //Goblin Army Craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/LeverActionShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 11;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ModContent.ItemType<RustyMechanicalParts>(), 5);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe2.AddIngredient(ModContent.ItemType<RustyMechanicalParts>(), 5);
            recipe2.AddIngredient(ItemID.PlatinumBar, 12);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

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

        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}