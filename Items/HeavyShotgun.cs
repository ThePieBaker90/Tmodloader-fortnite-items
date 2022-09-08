﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class HeavyShotgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavy Shotgun");
			Tooltip.SetDefault("A single slug shotgun with a high crit rate\n\"Is it really a shotgun at this point?\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//intended to be an early hardmode "shotgun" (more like a sniper with the shape of a shotgun)
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
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 30;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 25;
			Item.ArmorPenetration = 10;
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
		
	}
}