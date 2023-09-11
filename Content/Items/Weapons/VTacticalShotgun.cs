using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class VTacticalShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/VTacticalShotgun";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vindertech Tactical Shotgun");
            // Tooltip.SetDefault("Fast firing shotgun that excels at sustained close range damage\n\"With you since the first loop\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a basic post skeletron shotgun that hits hard 
        public override void SetDefaults()
        {

            Item.damage = 4;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Green; //Early prehardmode crafted sea remains
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/VTacticalShotgunShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 7;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 5;
            Item.ArmorPenetration = 10;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("SeaRemains", out ModItem SeaRemains))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
                recipe.AddIngredient(SeaRemains.Type, 3);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }//Adds bloodorb recipe if calamity mod is installed
            else
            {
                Recipe recipe2 = CreateRecipe();
                recipe2.AddIngredient(ItemID.DemoniteBar, 10);
                recipe2.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
                recipe2.AddTile(TileID.Anvils);
                recipe2.Register();

                Recipe recipe3 = CreateRecipe();
                recipe3.AddIngredient(ItemID.CrimtaneBar, 10);
                recipe3.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
                recipe3.AddTile(TileID.Anvils);
                recipe3.Register();
            }
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {
            const int NumProjectiles = 4; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}