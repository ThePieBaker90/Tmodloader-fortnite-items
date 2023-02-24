using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class RedEyeAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red-Eye Assault Rifle");
            Tooltip.SetDefault("20% chance to not consume ammo\nRight click to zoom out\n\"Directions: Place red dot on enemy, shoot gun.\"");
            //Front towards enemy
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //
        public override void SetDefaults()
        {
            Item.damage = 73;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 7, silver: 20);
            Item.rare = ItemRarityID.Pink; //Post Cryo
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ScopedARShoot")
            {
                Volume = 0.8f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 18;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("CryonicBar", out ModItem Cryonic))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(Cryonic.Type, 6);
                recipe.AddIngredient(ModContent.ItemType<Scar>(), 1);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }//Adds exotic recipe if calamity is installed
            else
            {
                //NOTHING! this item is calamity exclusive!
            }


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

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.20f;
        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}