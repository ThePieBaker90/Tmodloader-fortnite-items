using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class RapidFireSMG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rapid-Fire Submachine Gun");
			Tooltip.SetDefault("75% chance to not consume ammo\n\"Shadow standard issue SMG\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//Intended to be an early game smg
		public override void SetDefaults()
		{

			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.LightRed; //Pre Hardmode King Slime
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/RapidFireSMGShoot")
			{
				Volume = 0.6f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 7;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
			recipe.AddIngredient(ItemID.SwiftnessPotion, 5);
			recipe.AddIngredient(ModContent.ItemType<MakeshiftSMG>(), 1);
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


			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(11)); //Random Bullet Spread
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.75f;
		}


	}
}