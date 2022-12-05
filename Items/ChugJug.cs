using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FortniteItems.Items
{
	public class ChugJug : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chug Jug");
			Tooltip.SetDefault("Heals the User 400 Health\nGrants \"100% Shield\" buff\nQuick heal grants health and has an instant drinking time but grants no buff\nStandard drinking grants health and buff but has a 2 second drinking time\n\"I really love to Chug Jug with you\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(47, 254, 198),
				new Color(59, 254, 237),
				new Color(59, 254, 254)
			};
		}


		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 120;
			Item.useTime = 120;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Purple; //Post Moonlord
			Item.value = Item.buyPrice(gold: 1);

			Item.buffType = ModContent.BuffType<Buffs.Shield100>(); // Applies "Shield 100" (40 Defense)
			Item.buffTime = 28800; // Lasts 8 Minutes

			Item.healLife = 400; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
			Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
		}
	}
}
