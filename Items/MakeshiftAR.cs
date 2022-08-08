using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
	public class MakeshiftAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Makeshift Assault Rifle");
			Tooltip.SetDefault("10% chance to not consume ammo\nInaccurate yet consistent\n\"Atleast you can craft with it\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//an early game rifle that is outclassed by nearly every other rifle in the game and is mainly used as a material
		public override void SetDefaults()
		{

			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.1f;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue; //Early prehardmode crafted with demonite(or crimtane)
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 15;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ebonwood, 15);
			recipe.AddRecipeGroup(nameof(ItemID.IronBar), 12);
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 1);
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

			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10)); //Random Bullet Spread

		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.25f;
		}

	}
}