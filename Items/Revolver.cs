using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class Revolver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Revolver");
			Tooltip.SetDefault("\"A staple of the wild west LTM\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//an early game pistol
		public override void SetDefaults()
		{

			Item.damage = 78;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(gold: 4, silver: 80);
			Item.rare = ItemRarityID.LightRed; //Post WoF
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/RevolverShoot")
			{
				Volume = 0.6f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 15;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpiderFang, 12); ;
			recipe.AddIngredient(ModContent.ItemType<MakeshiftPistol>());
			recipe.AddTile(TileID.MythrilAnvil);
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