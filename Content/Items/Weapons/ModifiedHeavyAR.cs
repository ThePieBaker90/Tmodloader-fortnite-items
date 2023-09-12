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
    public class ModifiedHeavyAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ModifiedHeavyAR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Modified Heavy Assault Rifle");
            // Tooltip.SetDefault("50% chance not to consume ammo\nan extremely fast firing assault rifle that suffers from high spread\n\"Hit em Faster than they can blink!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a slow firing assault rifle dropped by mothron with high armor penetration
        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 65;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;//Mothron Drop
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/HeavyARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HeavyAR>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2.5f)); //Random Bullet Spread
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.5f;

        }
    }
}