using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class ModifiedRevolver : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ModifiedRevolver";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Modified Revolver");
            // Tooltip.SetDefault("Fires a weak spread of venom bullets along with its powerful shot\n\"A staple of revolver gods\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = 54;
            Item.DamageType = ModContent.GetInstance<PistolClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(gold: 4, silver: 80);
            Item.rare = ItemRarityID.LightRed; //Post WoF
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedRevolverShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 15;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Revolver>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

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


        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {
            const int NumProjectiles = 5; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                // Create a projectile.
                var projectile = Projectile.NewProjectileDirect(source, position, newVelocity, ProjectileID.VenomBullet, 7, 0, player.whoAmI);
                projectile.timeLeft = 20;
                projectile.ArmorPenetration = 10;
            }

            return true; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}