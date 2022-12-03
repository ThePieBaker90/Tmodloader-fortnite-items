using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class PrimalShotgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primal Shotgun");
			Tooltip.SetDefault("A two burst shotgun with a wide spread but fast speed and high damage\nChlorophyte bullets make the shot gun deal extra damage and fire faster, but they get turned into high velocity bullets\n\"The island has grown wild, and so must you\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a pre-plantera shotgun that has high damage and speed but is innacurate and cannot fire chlorophyte bullets
		public override void SetDefaults()
		{

			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 11;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ItemRarityID.LightPurple; //Pre Plantera Shotgun made with Chlorophyte
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 5;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 0;
			Item.reuseDelay = 44;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddIngredient(ItemID.Stinger, 5);
			recipe.AddIngredient(ItemID.JungleSpores, 3);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
			recipe.AddTile(TileID.AdamantiteForge); //Works as both titanium and adamantite forges
			recipe.Register();

		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-11f, 0);
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
				type = ModContent.ProjectileType<Projectiles.PrimalBullet>();
				Item.damage = 16;
				Item.reuseDelay = 33;
			}

			if (type != ProjectileID.ChlorophyteBullet)
            {
				if (type != ModContent.ProjectileType<Projectiles.PrimalBullet>())
                {
					Item.damage = 8;
					Item.reuseDelay = 44;
				}
					
			}

			if (type == ModContent.ProjectileType<Projectiles.PrimalBullet>())
            {
				Item.damage = 16;
				Item.reuseDelay = 33;
			}
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

		{
			const int NumProjectiles = 16; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(60));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.2f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile


			}
		}
	}
