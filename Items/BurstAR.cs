using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class BurstAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burst Assault Rifle");
			Tooltip.SetDefault("Shoots in bursts of 3, Musket balls are turned into meteor shot\n\"Gotta get that W, 3 shots at a time\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a post evil boss rifle intended for early game sustained damage
		public override void SetDefaults()
		{

			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 3;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(silver: 40);
			Item.rare = ItemRarityID.Green; //Mid Pre Hardmode Craft from Meteorite
			Item.UseSound = SoundID.Item31;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 70;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 30;
			Item.reuseDelay = 30;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.5f)); //Random Bullet Spread

			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.MeteorShot;
			}
		}


	}
}