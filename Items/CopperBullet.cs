using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class CopperBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Bullet");
			Tooltip.SetDefault("a crude bullet made out of a soft metal"); // The item's description, can be set to whatever you want.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 1; //Damage is weak as it is added to the musket ball projectile. the reason the musket ball projectile is used is so it is overlapped by bullet modifications
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(copper: 2);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.Bullet; // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 16f; // The speed of the projectile.
			Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(75);
			recipe.AddIngredient(ItemID.CopperBar, 1); ;
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe(75);
			recipe2.AddIngredient(ItemID.TinBar, 1); ;
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();


		}
	}
}