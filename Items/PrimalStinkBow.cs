using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class PrimalStinkBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primal Stink Bow");
            Tooltip.SetDefault("Shoots arrows at a high velocity\nChanges Wooden Arrows into Stink Arrows\n\"How Primal!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = 59;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Green; //Pre Hardmode, crabulon recommended but not required
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
            recipe.AddTile(TileID.Anvils);
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
