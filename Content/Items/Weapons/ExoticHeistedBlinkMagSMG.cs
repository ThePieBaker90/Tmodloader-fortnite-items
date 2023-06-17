using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Input;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Buffs;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHeistedBlinkMagSMG : ModItem
    {
        bool teleporting = false;
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedBlinkMagSMG";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Heisted Blink Mag SMG");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("AstralBar", out ModItem Astral))
            {
                Item.useTime = 6;
                Item.useAnimation = 6;
                Item.damage = 33;
            }
            {
                Item.useTime = 5;
                Item.useAnimation = 5;
                Item.damage = 40;
            }

            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 16);
            Item.rare = ModContent.RarityType<Exotic>(); //post astrum deus
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

            if (calamityMod != null && calamityMod.TryFind("AstralBar", out ModItem Astral))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(Astral.Type, 5);
                recipe.AddIngredient(ModContent.ItemType<TwinMagSMG>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds exotic recipe if calamity is installed
            else
            {
                //Gotten by putting a TwinMagSMG into shimmer after the moonlord has been defeated
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

            if (player.altFunctionUse == 2)
            {
                teleporting = true;
                if (!player.HasBuff<MatterDerealization>())
                {
                    if (!Collision.SolidCollision(Main.MouseWorld, player.width, player.height))
                    {

                        player.AddBuff(ModContent.BuffType<MatterDerealization>(), 1800);
                        player.Teleport(Main.MouseWorld, 1);

                    }

                }
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {
            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            if (teleporting == false)
            {
                for (int i = 0; i < NumProjectiles; i++)
                {
                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));

                    // Decrease velocity randomly for nicer visuals.
                    newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                    // Create a projectile.
                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }
            }
            else
            {

                teleporting = false;
            }


            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.40f;
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
    }
}