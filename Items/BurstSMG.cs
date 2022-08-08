using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class BurstSMG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burst Submachine Gun");
			Tooltip.SetDefault("75% chance to not consume ammo\nShoots in bursts of 4\n\"The Future is Yours\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//Intended to be an early game smg with a low chance to drop from man eaters and other npcs like that
		public override void SetDefaults()
		{

			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 3;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item31;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 70;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.reuseDelay = 14;
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


			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9)); //Random Bullet Spread
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.75f;
		}


	}
}