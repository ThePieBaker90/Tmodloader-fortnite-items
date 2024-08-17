using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Input;
using FortniteItems.Content.Projectiles;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{

    public class ChargeShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ChargeShotgun";
        public override void SetStaticDefaults()
        {
            /* Name: 
             *  Charge Shotgun
             * 
             * Description: 
             *  a Shotgun which charges up shots with the use button
             *  Can load a maximum of 7 shots before bullets start misfiring
             *  "Get ready for the pain train!"
             * 
             * Obtain Point:
             *  Bought from Arms Dealer after Duke Fishron Defeated
             *  
             * Intent:
             *  This is intended to be a post duke fishron shotgun that deals high damage at the cost of charge time 
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        
        public override void SetDefaults()
        {

            Item.damage = 500;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(gold: 25);
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Yellow; //post dukefishron arms dealer buy
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ChargeShotgunShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 1;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

            
            
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
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ChargeShotgunProjectile>(), damage, knockback, player.whoAmI);

            

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


    }
}