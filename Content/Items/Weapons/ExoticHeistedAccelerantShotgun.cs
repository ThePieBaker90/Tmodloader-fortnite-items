using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHeistedAccelerantShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedAccelerantShotgun";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Heisted Accelerant Shotgun");
            // Tooltip.SetDefault("The more enemies that are nearby, the faster the gun shoots\n\"Goldie's Weapon of Choice\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 120;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 7);
            Item.rare = ModContent.RarityType<Exotic>(); //Exotic
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

            if (calamityMod != null && calamityMod.TryFind("Phantoplasm", out ModItem Phantoplasm) && calamityMod.TryFind("RuinousSoul", out ModItem Soul))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<MavenAutoShotgun>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(Phantoplasm.Type, 10);
                recipe.AddIngredient(Soul.Type, 4);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds recipe if calamity mod is installed
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.LunarBar, 12);
                recipe.AddTile(TileID.LunarCraftingStation);
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
            const int NumProjectiles = 5; // The humber of projectiles that this gun will shoot.
            float activeNPCs = player.nearbyActiveNPCs;
            int fireRateInt = 0;
            fireRateInt = Convert.ToInt32(30 - 30 * (0.16 * activeNPCs) / (0.16 * activeNPCs + 1));
            //A modified version of the equation from ror2's safer spaces calculation. Dont ask why because I dont know why either.
            //I realize critters count to the total but I cant figure out how to fix it, this weapon is already a nightmare to
            //bug check and balance so it is going to be kept in as a cheese strategy
            Item.useTime = fireRateInt;
            Item.useAnimation = fireRateInt;

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


    }
}