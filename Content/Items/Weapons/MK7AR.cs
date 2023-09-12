using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class MK7AR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MK7AR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("MK-Seven Assault Rifle");
            // Tooltip.SetDefault("70% chance to not consume ammo\nTurns musket balls into twilight lances\n\"One of the seven\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a fast rifle 
        public override void SetDefaults()
        {

            Item.damage = 33;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 4;
            Item.useAnimation = 4;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 5);
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ItemRarityID.Red; //Post EoL
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MK7ARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
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

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.FairyQueenRangedItemShot;
            }


        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.70f;

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}
