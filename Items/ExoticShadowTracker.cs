using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using FortniteItems.Rarities;
using Terraria.Audio;
using FortniteItems.Items;

namespace FortniteItems.Items
{
    public class ExoticShadowTracker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Tracker");
            Tooltip.SetDefault("Exotic Weapon\n35% chance to not use ammo\nShoots ichor bullets instead of musket balls\n\"Track them and wait for your moment to strike\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //mech boss suppressed pistol
        public override void SetDefaults()
        {

            Item.damage = 44;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(gold: 8);
            Item.rare = ModContent.RarityType<Exotic>();  //Exotic
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SuppressedPistolShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 200;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BlackFairyDust, 1); ;
            recipe.AddIngredient(ModContent.ItemType<SuppressedPistol>());
            recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.SpookyTwig, 1); ;
            recipe2.AddIngredient(ModContent.ItemType<SuppressedPistol>());
            recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
            recipe2.AddTile(TileID.AdamantiteForge);
            recipe2.Register();


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

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.IchorBullet;
            }



        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.35f;
        }

    }
}
