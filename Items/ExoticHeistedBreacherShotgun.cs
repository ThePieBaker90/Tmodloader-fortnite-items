using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace FortniteItems.Items
{
    public class ExoticHeistedBreacherShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exotic Heisted Breacher Shotgun");
            Tooltip.SetDefault("A single slug \"Shotgun\" that fires a projectile which destroys tiles\n\"Chaos Double Agent's weapon of choice\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override string Texture => $"{nameof(FortniteItems)}/Items/ExoticHeistedBreacherShotgun";

        //intended to be an early hardmode "shotgun" (more like a utility rocket launcher)
        public override void SetDefaults()
        {

            Item.damage = 103;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(gold: 5);
            Item.value = Item.buyPrice(gold: 25);
            Item.rare = ItemRarityID.LightRed; //Early Hardmode Sold by Arms Dealer
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/HeavyShotgunShoot")
            {
                Volume = 0.75f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 50;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = -4;
            Item.ArmorPenetration = 0;
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