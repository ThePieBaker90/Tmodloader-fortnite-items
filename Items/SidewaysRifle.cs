using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class SidewaysRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sideways Rifle");
			Tooltip.SetDefault("Does not use ammo and shoots a bouncing laser\n\"Miss? try again!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//a post skeletron gun that has infinite ammo
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 65;
			Item.height = 40;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Green; //Post World Evil Boss crafted with Tissue Sample/Shadow Scales
			Item.UseSound = SoundID.Item72;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.ShadowBeamFriendly;
			Item.shootSpeed = 20;
			Item.noMelee = true;
			Item.ArmorPenetration = 30;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 12);
			recipe.AddRecipeGroup(nameof(ItemID.ShadowScale), 10);
			recipe.AddTile(TileID.DemonAltar);
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

		}


	}
}