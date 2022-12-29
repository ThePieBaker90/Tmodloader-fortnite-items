using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using FortniteItems.Rarities;
using Terraria.Audio;

namespace FortniteItems.Items
{
	public class ExoticBurstPulseRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burst Pulse Rifle");
			Tooltip.SetDefault("Exotic Weapon\na Magic rifle that fires a 3 projectiles in a burst that explodes upon impact\n\"The last Reality's weapon of choice\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		//UNFINISHED Obtained post plantera
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Magic; // Makes the damage register as magic.
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 7;
			Item.useAnimation = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ModContent.RarityType<Exotic>(); //UNFINISHED
			Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/BurstPulseRifleShoot")
			{
				Volume = 0.7f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MagicMissile; // shoots a blue laser bolt
			Item.shootSpeed = 7; // How fast the item shoots the projectile.
			Item.crit = 16; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
			Item.mana = 11; // This is how much mana the item uses.
			Item.reuseDelay = 23
				
				;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PulseRifle>(), 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();


		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-9f, 1f);
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