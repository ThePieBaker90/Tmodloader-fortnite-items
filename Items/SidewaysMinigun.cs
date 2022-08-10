using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

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
		//a post skeletron gun that has infinite ammo
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green; //Post World Evil Boss crafted with Tissue Sample/Shadow Scales
			Item.UseSound = SoundID.Item72;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.ShadowBeamFriendly;
			Item.shootSpeed = 6.76f;
			Item.noMelee = true;
			Item.ArmorPenetration = 5;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 10);
			recipe.AddRecipeGroup(nameof(ItemID.ShadowScale), 12);
			recipe.AddTile(TileID.DemonAltar);
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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8f)); //Random Bullet Spread

		}


	}
}