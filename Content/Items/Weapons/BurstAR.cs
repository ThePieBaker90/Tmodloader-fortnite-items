using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class BurstAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/BurstAR";

        public override void SetStaticDefaults()
        {

            /* Name: 
             *  Burst Assault Rifle
             * 
             * Description: 
             *  Shoots in bursts of 3, Musket balls are turned into meteor shot
             *  "Gotta get that W, 3 shots at a time"
             * 
             * Obtain Point:
             *  Metorite Craft
             *  
             * Intent:
             *  This is intended to be a pre-skeletron rifle used for sustained fire
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 11;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 3;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(silver: 40);
            Item.rare = ItemRarityID.Green; //Mid Pre Hardmode Craft from Meteorite
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BurstARShoot")
            {
                Volume = 0.9f,
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
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<ModifiedBurstAR>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe2.AddTile(TileID.TinkerersWorkbench);
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.5f)); //Random Bullet Spread

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.MeteorShot;
            }
        }


    }
}