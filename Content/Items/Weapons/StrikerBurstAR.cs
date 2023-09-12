using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class StrikerBurstAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/StrikerBurstAR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Striker Burst Assault Rifle");
            // Tooltip.SetDefault("Shoots in bursts of 3, Musket balls are turned into nanite bullets\n\"Bounce back at em!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a pre plantera burst rifle that bounces off of walls
        public override void SetDefaults()
        {

            Item.damage = 55;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 3;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.LightPurple; //chlorophyte craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BurstARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 70;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 45;
            Item.reuseDelay = 25;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpookyWood, 300);
            recipe.AddIngredient(ModContent.ItemType<BurstAR>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
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


            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.NanoBullet;
            }
        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }


    }
}