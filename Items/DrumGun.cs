﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class DrumGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drum Gun");
			Tooltip.SetDefault("Shoots a consistent yet inaccurate stream of bullets\n\"It's back for round Two!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//Intended to be an early game upgrade to the Minishark
		public override void SetDefaults()
		{

			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
			Item.rare = ItemRarityID.Orange; //Obtained after the meteor has landed and a minishark has been bought
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 0;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

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
				type = ProjectileID.MeteorShot;
			}

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5f)); //Random Bullet Spread

		}
	}
}