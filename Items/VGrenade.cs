using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class VGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vindertech Grenade");
			Tooltip.SetDefault("25% chance not to consume grenade\nExplodes after a set amount of time instead of upon impact\n\"Gotta get that W\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		//Post eye consumable gotten from the demo man
		public override void SetDefaults()
		{

			Item.damage = 999;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0.2f;
			Item.value = Item.sellPrice(copper: 50);
			Item.value = Item.buyPrice(silver: 5);
			Item.rare = ItemRarityID.Blue; //Post Eye Sold by Demo
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.VGrenade>();
			Item.shootSpeed = 10;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.ArmorPenetration = 25;
			Item.consumable = true;
			Item.maxStack = 999;
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-9f, 0);
		}
		

	}
}