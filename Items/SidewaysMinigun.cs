using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class SidewaysMinigun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sideways Minigun");
			Tooltip.SetDefault("Does not use ammo, has a large spread, and shoots a bouncing laser\n\"Miss? try again!... and again!... and again!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//gun that has infinite ammo
		public override void SetDefaults()
		{
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(silver: 36);
			Item.rare = ItemRarityID.Blue; //Post EoC
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SidewaysMinigunShoot")
			{
				Volume = 0.9f,
				PitchVariance = 0.2f,
				MaxInstances = 10,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.ShadowBeamFriendly;
			Item.shootSpeed = 6.76f;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.CorruptSeeds, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe2.AddIngredient(ItemID.CrimsonSeeds, 1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5f, 7f);
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8f)); //Random Bullet Spread

		}


	}
}