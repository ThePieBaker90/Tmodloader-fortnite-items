using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class MK7AR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MK7 Assault Rifle");
			Tooltip.SetDefault("70% chance to not consume ammo\nTurns musket balls into high velocity bullets\n\"One of the seven\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a direct upgrade to the Combat AR
		public override void SetDefaults()
		{

			Item.damage = 80;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.1f;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Red; //Post Moon Lord requiring Luminite
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 70;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.ArmorPenetration = 30;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ModContent.ItemType<CombatAR>(), 1);
			recipe.AddIngredient(ItemID.SDMG, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
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

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.70f;

		}

	}
}