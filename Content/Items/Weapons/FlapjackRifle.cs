using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Weapons
{
    public class FlapjackRifle : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FlapjackRifle";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Light Machine Gun");
            // Tooltip.SetDefault("70% chance not to consume ammo\n\"Hit em hard and fast... or miss em hard and fast\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a hardmode minigun equivalent
        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.3f;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Yellow; //Duke fishron drop
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/FlapjackRifleShoot")
            {
                Volume = 0.8f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.ArmorPenetration = 3;
            Item.useAmmo = AmmoID.Bullet;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6f)); //Random Bullet Spread

        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;

        }
    }
}