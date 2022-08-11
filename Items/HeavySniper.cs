using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class HeavySniper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavy Sniper Rifle");
			Tooltip.SetDefault("Cannot fire chlorophyte bullets\nTurns musket balls into high velocity bullets\nFires a high damage bullet at the cost of firing speed\n\"Gotta get that W\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a hardmode sniper rifle that is crafted with the sniper rifle found in the dungeon and shroomite
		public override void SetDefaults()
		{

			Item.damage = 550;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 90;
			Item.useAnimation = 90;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(gold: 10, silver: 50);
			Item.rare = ItemRarityID.Lime; //Post Plantera Sniper Rifle Crafted with Shroomite
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 200;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 200;
			Item.crit = 10;
            
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddIngredient(ItemID.SniperRifle, 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			Recipe altrecipe = CreateRecipe();
			altrecipe.AddIngredient(ItemID.ShroomiteBar, 12);
			altrecipe.AddIngredient(ItemID.SniperScope, 1);
			altrecipe.AddIngredient(ItemID.IllegalGunParts, 1);
			altrecipe.AddIngredient(ModContent.ItemType<Scar>());
			altrecipe.AddTile(TileID.Autohammer);
			altrecipe.Register();

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

			if (type == ProjectileID.ChlorophyteBullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}

			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}

			
		}


	}
}