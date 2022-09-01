using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class Minigun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Minigun");
			Tooltip.SetDefault("70% chance not to consume ammo\nHas a large spread and fast fire rate\n\"Miss? you'll hit eventually!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a hallowed gun alternative to the hallowed repeater
		public override void SetDefaults()
		{
			Item.damage = 15; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5; 
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.3f; 
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Pink; 
			Item.UseSound = SoundID.Item11; 
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 7f; 
			Item.noMelee = true;
			Item.ArmorPenetration = 3;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(7f)); //Random Bullet Spread

		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.70f;

		}
	}
}