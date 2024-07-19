using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class ChargeSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ChargeSMG";
        public override void SetStaticDefaults()
        {
            /* Name: 
             *  Charge Submachine Gun
             * 
             * Description: 
             *  90% chance not to consume ammo
             *  Shoots in bursts of 32 but has a long reuse time
             *  "The new spray and pray"
             * 
             * Obtain Point:
             *  Dropped by Elf Copter (frost moon)
             *  
             * Intent:
             *  This is intended to be a post plantera, pre golem smg with long uptime yet long downtime aswell   
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 12;
            Item.DamageType = ModContent.GetInstance<SubmachineGunClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 64;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.01f;
            Item.value = Item.sellPrice(gold: 9);
            Item.rare = ItemRarityID.Lime; //Frost moon elf copter drop
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ChargeSMGShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.reuseDelay = 55;
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


            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8)); //Random Bullet Spread
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.90f;
        }


    }
}