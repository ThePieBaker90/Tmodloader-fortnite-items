﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class SmallShieldPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Small Shield Potion");
			Tooltip.SetDefault("Grants \"25% Shield\" buff\n\"Minis Here!\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(47, 254, 198),
				new Color(59, 254, 237),
				new Color(59, 254, 254)
			};
		}

		public override void AddRecipes()
		{
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			
			if (calamityMod != null && calamityMod.TryFind<ModItem>("BloodOrb", out ModItem BloodOrb))
			{
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.BottledWater, 1);
				recipe.AddIngredient(BloodOrb.Type, 15);
				recipe.AddTile(TileID.AlchemyTable);
				recipe.Register();
			}//Adds bloodorb recipe if calamity mod is installed

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.ShadowScale, 1);
			recipe2.AddIngredient(ItemID.BottledWater, 1);
			recipe2.AddIngredient(ItemID.Moonglow, 1);
			recipe2.AddIngredient(ItemID.Deathweed, 1);
			recipe2.AddTile(TileID.Bottles);
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.TissueSample, 1);
			recipe3.AddIngredient(ItemID.BottledWater, 1);
			recipe3.AddIngredient(ItemID.Moonglow, 1);
			recipe3.AddIngredient(ItemID.Deathweed, 1);
			recipe3.AddTile(TileID.Bottles);
			recipe3.Register();


		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 120;
			Item.useTime = 120;
			Item.useTurn = true;
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Consumables/SmallShieldPotionDrink")
			{
				Volume = 2f,
				PitchVariance = 0.2f,
				MaxInstances = 1,
			};
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue; //Post 
			Item.value = Item.buyPrice(silver: 1);

			Item.buffType = ModContent.BuffType<Buffs.Shield025>(); // Applies "Shield 025" (10 Defense)
			Item.buffTime = 14400; // Lasts 8 Minutes

		}
	}
}
