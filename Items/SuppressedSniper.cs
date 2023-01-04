using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class SuppressedSniper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suppressed Sniper Rifle");
			Tooltip.SetDefault("Turns musket balls into high velocity bullets\n\"Strike from the shadows\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a post EoC sniper rifle
		public override void SetDefaults()
		{

			Item.damage = 150;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ItemRarityID.LightPurple; //Post Twin craft
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SuppressedSniperShoot")
			{
				Volume = 0.6f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 200;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 30;
			Item.crit = 10;

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BoltActionSniper>());
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddTile(TileID.AdamantiteForge);
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
				type = ProjectileID.BulletHighVelocity;
			}


		}
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }


    }
}