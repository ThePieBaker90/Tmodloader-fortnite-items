using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class InfantaryRifle : ModItem
    //The spelling mistake also bothers me
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/InfantaryRifle";
        public override void SetStaticDefaults()
        {

            /* Name: 
             * Infantry Rifle
             * 
             * Description: 
             * Turns musket balls into high velocity bullets
             * "When a sniper rifle and an assault rifle meet..."
             * 
             * Obtain Point:
             * Post Calamitas Clone / Post All Mechs
             *  
             * Intent:
             * This is intended to be an post calamitas clone rifle that is faster than other sniper rifles an has a high crit chance.
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a slow firing assault rifle acquired from mimics
        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 65;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.LightRed; //Early hardmode drop from mimics 1/6 and ice mimics 1/3
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/InfantryRifleShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16;
            Item.noMelee = true;
            Item.ArmorPenetration = 30;
            Item.useAmmo = AmmoID.Bullet;
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
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }
        }


    }
}
