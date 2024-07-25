using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class Flaregun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/Flaregun";

        public override void SetStaticDefaults()
        {
            /* Name: 
             * Flaregun
             * 
             * Description: 
             * "Unconventional, but who cares"
             * 
             * Obtain Point:
             * Pre Hardmode Requires atleast one trip to hell to get hellstone bricks from a ruined house.
             *  
             * Intent:
             * This is intended to be a post-cultist direct upgrade to the Pulse Rifle
             */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            Item.damage = 30;
            Item.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green; //Pre Hardmode
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/FlareGunShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 15;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Flare;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 12);
            recipe.AddIngredient(ItemID.HellstoneBrick, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
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