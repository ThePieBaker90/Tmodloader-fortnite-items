using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class Flaregun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flare Gun");
			Tooltip.SetDefault("\"Unconventional, but who cares\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//an early game rifle that is outclassed by nearly every other rifle in the game and is mainly used as a material
		public override void SetDefaults()
		{

			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6f;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green; //Goblin Army
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 15;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Flare;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 12);
			recipe.AddIngredient(ItemID.HellstoneBrick, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();

		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
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