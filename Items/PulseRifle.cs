﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class PulseRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pulse Rifle");
			Tooltip.SetDefault("a Magic rifle that fires a projectile that explodes upon impact\n\"Dr Slone's weapon of choice\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//UNFINISHED Obtained post plantera
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Magic; // Makes the damage register as magic.
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true; 
			Item.knockBack = 3;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.LightRed; //UNFINISHED
			Item.UseSound = SoundID.Item72;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MagicMissile; // shoots a blue laser bolt
			Item.shootSpeed = 7; // How fast the item shoots the projectile.
			Item.crit = 16; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
			Item.mana = 11; // This is how much mana the item uses.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 10);
			recipe.AddIngredient(ModContent.ItemType<Scar>(), 1);
			recipe.AddIngredient(ItemID.MagicMissile, 1);
			recipe.AddTile(TileID.Autohammer);
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

		}


		}
}