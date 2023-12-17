using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Content.Items.Materials;

namespace FortniteItems.Content.Items.Weapons
{
    public class MKAlphaAR : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MKAlphaAR";
        public override void SetStaticDefaults()
        {
            /* Name: 
             *  MK-Alpha Assault Rifle
             * 
             * Description: 
             *  50% chance to not consume ammo
             *  An assault rifle that deals consistent medium range damage
             *  "Not to be confused with the MK-Seven Assault Rifle"
             * 
             * Obtain Point:
             *  Pre Plant Solar Eclipse Craft
             *  
             * Intent:
             *  Medium damage, medium knockback, medium fire rate (for a rifle)
             *  generalist weapon for lots of scenarios
             */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {

            Item.damage = 20;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MK7ARShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 12,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 10;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>());
            recipe.AddIngredient(ModContent.ItemType<MechanicalParts>(), 5);
            recipe.AddTile(TileID.AdamantiteForge);
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2f)); //Random Bullet Spread
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;

        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}