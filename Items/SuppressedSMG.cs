using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class SuppressedSMG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suppressed Submachine Gun");
			Tooltip.SetDefault("50% chance to not use ammo\n\"Sounds like a whisper\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//Skeltron Prime SMG
		public override void SetDefaults()
		{

			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ItemRarityID.LightPurple; //Post Skeletron Prime
			Item.UseSound = SoundID.Item48;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 7;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SMG>());
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.AdamantiteForge);
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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));

		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.50f;
		}

	}
}