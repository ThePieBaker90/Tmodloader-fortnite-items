using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class ScopedAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scoped Assault Rifle");
			Tooltip.SetDefault("35% chance to not consume ammo\nTurns musket balls into high velocity bullets\n\"Gotta get that W, from a range\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a direct upgrade to the silenced assault rifle (or silenced scar)
		public override void SetDefaults()
		{
			Item.damage = 85;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Yellow; //Post Plantera Crafted with Shroomite
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 70;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 50;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SilencedScar>());
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ItemID.SniperScope, 1);
			recipe.AddTile(TileID.Autohammer);
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

			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.35f;
		}

	}
}