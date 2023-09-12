using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class DrumGun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/DrumGun";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Drum Gun");
            // Tooltip.SetDefault("25% chance to not consume ammo\nTurns musket balls into meteor shot\n\"It's back for round Two!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Intended to be an early game upgrade to the Minishark
        public override void SetDefaults()
        {

            Item.damage = 13;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Orange; //Obtained after the meteor has landed and a minishark has been bought
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DrumGunShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeeWax, 12);
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-22f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.MeteorShot;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8f)); //Random Bullet Spread


        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.25f;
        }
    }
}
