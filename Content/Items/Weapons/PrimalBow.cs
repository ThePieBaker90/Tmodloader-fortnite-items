using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class PrimalBow : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/PrimalBow";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primal Bow");
            // Tooltip.SetDefault("Shoots arrows at a high velocity\n\"How Primal!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = 38;
            Item.DamageType = ModContent.GetInstance<BowClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(silver: 40);
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
            recipe.AddIngredient(ItemID.GlowingMushroom, 20);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftBow>(), 1);
            recipe.AddIngredient(ItemID.MushroomGrassSeeds, 3);
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


        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}
