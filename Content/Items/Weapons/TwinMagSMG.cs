using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Projectiles;
using Terraria.DataStructures;

namespace FortniteItems.Content.Items.Weapons
{
    public class TwinMagSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/TwinMagSMG";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Twin Mag SMG");

            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
            if (calamityMod != null)
            {
                // Tooltip.SetDefault("40% chance to not use ammo\nFires two bullets per shot\n\"Double the magazines! Double the fun!\"");
            }
            else
            {
                // Tooltip.SetDefault("How are you seeing this? Are you magic? Or Did You Accidentally Uninstall Calamity?");
            }

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //
        public override void SetDefaults()
        {

            Item.damage = 30;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 11);
            Item.rare = ItemRarityID.Lime; //post leviathan
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SMGShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 5;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("LeviathanAmbergris", out ModItem LA))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<MakeshiftSMG>(), 2);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddIngredient(LA.Type, 1);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();
            }//Adds bloodorb recipe if calamity mod is installed
            else
            {
                //NOTHING! this item is calamity exclusive!
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11f, 5f);
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
            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }



            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.40f;
        }
    }
}