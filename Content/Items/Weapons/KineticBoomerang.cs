using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using FortniteItems.Content.Projectiles;
using FortniteItems.Content.Items.Weapons;

namespace FortniteItems.Content.Items.Consumables
{
    public class KineticBoomerang : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/KineticBoomerang";
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        //Post eye consumable gotten from the demo man
        public override void SetDefaults()
        {

            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.sellPrice(copper: 50);
            Item.value = Item.buyPrice(silver: 5);
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
            Item.shootSpeed = 25;
            Item.noMelee = true;
            Item.ArmorPenetration = 25;
            Item.shoot = ModContent.ProjectileType<Projectiles.KineticBoomerangProjectile>();
            Item.noUseGraphic = true;
        }

        //Checks if the player already has a boomerang out.
        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddIngredient(ItemID.LargeAmethyst, 1);
            recipe.AddIngredient(ItemID.LightDisc, 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // NewProjectile returns the index of the projectile it creates in the NewProjectile array.
            // Here we are using it to gain access to the projectile object.
            int projectileID = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            Projectile projectile = Main.projectile[projectileID];

            GlobalProjectileModification globalProjectile = projectile.GetGlobalProjectile<GlobalProjectileModification>();
            // For more context, see ExampleProjectileModifications.cs
            globalProjectile.SetTrail(Color.Purple);

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }


    }
}
