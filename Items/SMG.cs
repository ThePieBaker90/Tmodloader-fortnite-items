using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class SMG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Submachine Gun");
			Tooltip.SetDefault("50% chance to not use ammo\n\"The old Spray 'n Pray\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//EoW SMG
		public override void SetDefaults()
		{

			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(silver: 75);
			Item.rare = ItemRarityID.Blue; //EoW BoC
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SMGShoot")
			{
				Volume = 0.7f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 5;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TissueSample, 5); 
			recipe.AddIngredient(ItemID.CrimtaneBar, 10); 
			recipe.AddIngredient(ModContent.ItemType<MakeshiftSMG>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.ShadowScale, 5);
			recipe2.AddIngredient(ItemID.DemoniteBar, 10);
			recipe2.AddIngredient(ModContent.ItemType<MakeshiftSMG>());
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();


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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));

		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.50f;
		}

	}
}