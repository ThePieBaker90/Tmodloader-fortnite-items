using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class DualPistols : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/DualPistols";
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Dual Barrel Pistol
             * 
             * Description: 
             * 33% chance to not use ammo
             * "It's a shame you can't just hold two pistols at once"
             * 
             * Obtain Point:
             * Bloodnautilus drop
             *  
             * Intent:
             * This weapon serves a purpose as a burst pistol for players with pistol buffs and adds a reason a ranged player may want to kill the dreadnautilus
             */

            //Even though the dual barrel pistol is not a thing in fortnite, there is no way that i've found to make the player appear to be holding two items at once
            //So this is my workaround, it will work the exact same way as the dual pistols, just a different name and look


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post plague burst pistol
        public override void SetDefaults()
        {
            Item.damage = 57;
            Item.value = Item.sellPrice(gold: 5);
            Item.knockBack = 1f;
            Item.useTime = 6;
            Item.useAnimation = 12 ;
            Item.reuseDelay = 12;
            Item.shootSpeed = 7;
            Item.DamageType = ModContent.GetInstance<PistolClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.LightRed; //Post Bloodnautilus
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DualPistolsShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }


        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.33f;
        }

    }
}
