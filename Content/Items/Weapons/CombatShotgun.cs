using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Assets.Methods;

namespace FortniteItems.Content.Items.Weapons
{
    public class CombatShotgun : ModItem 
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/CombatShotgun";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Combat Shotgun
             * 
             * Description: 
             * A longer range shotgun that penetrates armor
             * "Looks like someone needs a better gaming chair"
             * 
             * Obtain Point:
             *  Pirate Drop
             *  
             * Intent:
             *  This is intended to be an early hardmode shotgun with high armor penetration and range
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //intended to be an early hardmode long range shot gun
        public override void SetDefaults()
        {

            Item.damage = 35;
            Item.DamageType = ModContent.GetInstance<ShotgunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 3, silver: 60);
            Item.rare = ItemRarityID.LightRed; //Early Hardmode Drop from Pixies
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/CombatShotgunShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 2;
            Item.ArmorPenetration = 30;
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
            return ShotgunSpreadMethod.ShotGunShoot(player, source, position, velocity, type, damage, knockback, 3, 4);
        }

        
    }
}