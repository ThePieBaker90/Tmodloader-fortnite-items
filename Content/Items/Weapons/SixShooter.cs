using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Projectiles;
using Terraria.DataStructures;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class SixShooter : ModItem
    {
        int shotsFired = 1;
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/SixShooter";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Six Shooter");
            // Tooltip.SetDefault("Shoots six shots before needing to reload\nIncapable of critical shots\n\"This town ain't big enough...\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = 25;
            Item.DamageType = ModContent.GetInstance<PistolClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(silver: 80);
            Item.rare = ItemRarityID.Green; //Post EoC/Acid Rain
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SixShooterShoot")
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
            Item.crit = -4;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("SulphuricScale", out ModItem SulphuricScale))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(SulphuricScale.Type, 15);
                recipe.AddIngredient(ModContent.ItemType<MakeshiftPistol>(), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }//Adds calamity recipe if calamity is... installed
            else
            {
                //if calamity is not installed, this is an EoC drop instead
            }
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
            if (shotsFired >= 5)
            {
                Item.reuseDelay = 114;
                shotsFired = 0;
                Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SixShooterReload")
                {
                    Volume = 0.9f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
            }
            else if (shotsFired <= 4)
            {
                shotsFired++;
                Item.reuseDelay = 0;
                Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SixShooterShoot")
                {
                    Volume = 0.6f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
            }

            return true;
        }
    }
}