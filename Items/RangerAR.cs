using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class RangerAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ranger Assault Rifle");
			Tooltip.SetDefault("10% chance to not consume ammo\nfires explosive bullets but is slightly inaccurate\n\"Hit them hard and hit them fast!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//Intended to be an early hardmode weapon, equivalent to a 3rd tier repeater
		public override void SetDefaults()
		{

			Item.damage = 45; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40; 
			Item.height = 40;
			Item.useTime = 17; 
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(gold: 3, silver: 20);
			Item.rare = ItemRarityID.LightRed; //Pirate Invasion drop
			Item.UseSound = SoundID.Item11; 
			Item.autoReuse = true; 
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 40; 
			Item.crit = 3;
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
				type = ProjectileID.ExplosiveBullet;
			}


			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3f));
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.1f;
		}

	}
}