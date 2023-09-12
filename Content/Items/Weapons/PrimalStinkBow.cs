using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class PrimalStinkBow : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/PrimalStinkBow";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primal Stink Bow");
            // Tooltip.SetDefault("Shoots arrows at a high velocity\nChanges Wooden Arrows into Primal Stink Arrows\n\"Like a long range stink grenade!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            Item.damage = 120;
            Item.DamageType = ModContent.GetInstance<BowClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow; //Post Plant Lunar Eclipse Craft
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ToxicFlask, 1);
            recipe.AddIngredient(ModContent.ItemType<PrimalBow>(), 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
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
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<Projectiles.StinkArrow>();
            }

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}
