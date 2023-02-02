using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Input;
using FortniteItems.Projectiles;

namespace FortniteItems.Items
{
    public class ChargeShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charge Shotgun");
            Tooltip.SetDefault("a Shotgun which charges up shots with the right click button\nCan load a maximum of 6 shots before bullets start misfiring\n\"Get ready for the pain train!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a basic post skeletron shotgun that hits hard 
        public override void SetDefaults()
        {

            Item.damage = 23;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(gold: 20);
            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.Green; //Early prehardmode crafted with demonite(or crimtane)
            Item.UseSound = SoundID.CoinPickup;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 1;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 5;
            Item.ArmorPenetration = 10;
           
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ModifiedPumpShotgun>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            Item.autoReuse = false;
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ChargeShotgunProjectile>(), damage, knockback, player.whoAmI);
            
            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}