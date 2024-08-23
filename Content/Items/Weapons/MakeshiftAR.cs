using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class MakeshiftAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MakeshiftAR";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Makeshift Assault Rifle
             * 
             * Description: 
             * 10% chance to not consume ammo
             * "Atleast you can craft with it"
             * 
             * Obtain Point:
             * Pre Hardmode Craft
             *  
             * Intent:
             * A Pre boss assault rifle which also functions as a material for other assault rifles.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 8;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue; //Early prehardmode crafted with demonite(or crimtane)
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MakeshiftARShoot")
            {
                Volume = 0.4f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 8;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
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
            return new Vector2(-9f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10)); //Random Bullet Spread

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.10f;
        }

    }
}