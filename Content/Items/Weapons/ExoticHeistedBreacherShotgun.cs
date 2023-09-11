using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHeistedBreacherShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedBreacherShotgun";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Heisted Breacher Shotgun");
            // Tooltip.SetDefault("A single slug \"Shotgun\" that fires a projectile which destroys tiles\n\"Chaos Double Agent's weapon of choice\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }


        //intended to be an early hardmode "shotgun" (more like a utility rocket launcher)
        //Although this has a high dps, it destroys tiles making it a difficult "weapon" to use
        //My intent is for this to be more of a tool.
        public override void SetDefaults()
        {

            Item.damage = 103;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(gold: 5);
            Item.value = Item.buyPrice(gold: 25);
            Item.rare = ModContent.RarityType<Exotic>(); //exotic early hardmode craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/HeavyShotgunShoot")
            {
                Volume = 0.75f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = -4;
            Item.ArmorPenetration = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Explosives, 4);
            recipe.AddIngredient(ModContent.ItemType<HeavyShotgun>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-13f, 0);
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
            Projectile.NewProjectile(source, position, velocity, ProjectileID.RocketIV, damage, knockback, player.whoAmI);

            return false;
        }

    }
}