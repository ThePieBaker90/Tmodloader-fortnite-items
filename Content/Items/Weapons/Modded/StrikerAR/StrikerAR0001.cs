using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Content.Items.Materials;

namespace FortniteItems.Content.Items.Weapons.Modded.StrikerAR
{
    public class StrikerAR0001 : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/StrikerAR/0001StrikerAR";
        /// <summary>
        /// The textures have a string of 4 bits at the beginning of them, this is used to determine what mods the texture shows.
        /// The first bit is the suppressor
        /// The second bit is the angeled foregrip
        /// The third bit is the speed mag
        /// The fourth bit is the red eye sight
        /// (1 signifies the mod is enabled, 0 signifies the mod isn't)
        /// </summary>
        public override void SetStaticDefaults()
        {
            /* Name: 
             * Striker Assault Rifle 
             * 
             * Description: 
             * This is a hardmode version of the normal assault rifle that can be upgraded with weapon mods.
             * 
             * Obtain Point:
             * Hardmode with tier 1 metals.
             *  
             * Intent:
             * A fast firing assault rifle that is effective at short to medium ranges.
             */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 46;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 8, silver: 50);
            Item.rare = ItemRarityID.Lime; //frost moon
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/TacticalARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 21;
            Item.ArmorPenetration = 10;
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

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.45f;

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RedDotSight>(), 1);
            recipe.AddIngredient(ModContent.ItemType<StrikerAR0000>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }
}