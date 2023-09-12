using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class PrimalAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/PrimalAR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primal Assault Rifle");
            // Tooltip.SetDefault("25% chance to not consume ammo\nTurns chlorophyte bullets into primal bullets that deal extra damage and fire faster\n\"There is a primal force that binds us all\""); //UNFINISHED

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //UNFINISHED
        public override void SetDefaults()
        {

            Item.damage = 70;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.5f;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.LightPurple; //Pre Plantera Shotgun made with Chlorophyte
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/PrimalARShoot")
            {
                Volume = 0.4f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 3);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
            recipe.AddTile(TileID.AdamantiteForge); //Works as both titanium and adamantite forges
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10)); //Random Bullet Spread UNFINISHED

            if (type == ProjectileID.ChlorophyteBullet)
            {
                type = ModContent.ProjectileType<Projectiles.PrimalBullet>();
                Item.damage = 90;
                Item.useTime = 8;
                Item.useAnimation = 8;
            }

            if (type != ProjectileID.ChlorophyteBullet)
            {
                if (type != ModContent.ProjectileType<Projectiles.PrimalBullet>())
                {
                    Item.damage = 70;
                    Item.useTime = 12;
                    Item.useAnimation = 12;
                }

            }

            if (type == ModContent.ProjectileType<Projectiles.PrimalBullet>())
            {
                Item.damage = 90;
                Item.useTime = 8;
                Item.useAnimation = 8;
            }
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.25f;
        }

    }
}