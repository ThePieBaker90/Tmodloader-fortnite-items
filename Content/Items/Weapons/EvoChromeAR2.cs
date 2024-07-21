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
    public class EvoChromeAR2 : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/EvoChromeAR2";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * EvoChrome Assault Rifle MKII
             * 
             * Description: 
             * An assault rifle that is upgraded throughout the lunar events
             * Shoots in a 3 bullet burst
             * "Chrome Runs Rampant"
             * 
             * Obtain Point:
             * Lunar Events Craft
             *  
             * Intent:
             * Intended to be a lunar events gun that is upgraded throughout the event
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 61;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 3, silver: 60);
            Item.rare = ItemRarityID.Cyan; //Lunar Events
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MK2EvoChromeBurstShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 8;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.reuseDelay = 25;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChromeSample>(), 2);
            recipe.AddIngredient(ModContent.ItemType<EvoChromeAR1>());
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2)); //Random Bullet Spread


        }


    }
}