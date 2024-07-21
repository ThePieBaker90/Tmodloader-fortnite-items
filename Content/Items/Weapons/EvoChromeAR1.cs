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
    public class EvoChromeAR1 : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/EvoChromeAR1";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * EvoChrome Assault Rifle MKI
             * 
             * Description: 
             * An assault rifle that is upgraded throughout the lunar events
             * Shoots in a 2 bullet burst
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

            Item.damage = 60;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 4;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 3, silver: 60);
            Item.rare = ItemRarityID.Cyan; //Lunar Events
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MK1EvoChromeBurstShoot")
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
            Item.reuseDelay = 30;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChromeSample>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>());
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3)); //Random Bullet Spread


        }


    }
}