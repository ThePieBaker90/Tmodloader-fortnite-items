using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class ChargeSMG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charge SMG");
			Tooltip.SetDefault("90% chance not to consume ammo\nShoots in bursts of 32 but has a long reuse time\n\"The new spray and pray\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{

			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 2;
			Item.useAnimation = 64;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.01f;
			Item.value = Item.sellPrice(gold: 8, silver: 50);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item31;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 70;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.reuseDelay = 60;
			Item.ArmorPenetration = 3;
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


			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.90f;
		}


	}
}