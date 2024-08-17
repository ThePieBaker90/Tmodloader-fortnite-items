using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using Terraria.DataStructures;
using FortniteItems.Content.Items.Materials;

namespace FortniteItems.Content.Items.Weapons
{
    public class RailGun : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/RailGun";

        public override void SetStaticDefaults()
        {
            /* Name: 
             *  Rail Gun
             * 
             * Description: 
             *  A sniper rifle that shoots a piercing laser
             *  "Pairs great with the recon scanner"
             * 
             * Obtain Point:
             *  Post Martian Madness Craft
             *  
             * Intent:
             *  High damage, infinite pierce, with no knockback and a long use time.
             *  Useful for big groups of enemies, less useful with bosses.
             */
            //TODO: Needs a wiki page

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        
        public override void SetDefaults()
        {

            Item.damage = 880;
            Item.DamageType = ModContent.GetInstance<SniperRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 85;
            Item.useAnimation = 85;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.LightRed; 
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/RailGunShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 30;
            Item.crit = 10;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlienNanites>(), 5);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftSniper>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

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

            type = ModContent.ProjectileType<Projectiles.RailGunProjectile>();

        }

        

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}