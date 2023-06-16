using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHeistedExplosiveAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedExplosiveAR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Heisted Explosive Assault Rifle");
            // Tooltip.SetDefault("25% chance to not consume ammo\nFires an explosive projectile\nRight click to zoom out\n\"Cold Blooded Ace's weapon of choice\"");
            //Front towards enemy
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
            if (calamityMod != null && calamityMod.TryFind("PerennialBar", out ModItem Perennial))
            {
                Item.damage = 73;
            }
            else
            {
                Item.damage = 37;
            }

            
            
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 7, silver: 20);
            Item.rare = ModContent.RarityType<Exotic>(); //post plant
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ScopedARShoot")
            {
                Volume = 0.8f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shootSpeed = 20;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("PerennialBar", out ModItem Perennial))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(Perennial.Type, 6);
                recipe.AddIngredient(ModContent.ItemType<RedEyeAR>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }//Adds exotic recipe if calamity is installed
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.Nanites, 25);
                recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
                recipe.AddIngredient(ModContent.ItemType<RedEyeAR>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }


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

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ProjectileID.RocketI, damage, knockback, player.whoAmI);

            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.25f;
        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}