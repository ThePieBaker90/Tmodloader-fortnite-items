using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class HammerAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hammer Assault Rifle");
			Tooltip.SetDefault("20% chance to not consume ammo\nTurns musket balls into explosive bullets\n\"Drop the Hammer\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a pre-hardmode rifle alternative to the pheonix blaster
		public override void SetDefaults()
		{

			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
			Item.rare = ItemRarityID.Orange; //made of hellstone
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 10;
			Item.crit = 6;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Hellforge); //Hell forge
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
				type = ProjectileID.ExplosiveBullet;
			}


			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2f));
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.2f;
		}

	}
}