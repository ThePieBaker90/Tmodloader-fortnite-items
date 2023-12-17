using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Ammo;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class MechanicalExplosiveBow : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MechanicalExplosiveBow";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Bow");
            // Tooltip.SetDefault("Shoots arrows at a high velocity\n\"How Mechanical!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            Item.damage = 95;
            Item.DamageType = ModContent.GetInstance<BowClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(gold: 3, silver: 50);
            Item.rare = ItemRarityID.Yellow; //Post Golem
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 28;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Arrow;
        }

        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ExplosiveArrow>(), 50);
            recipe.AddIngredient(ModContent.ItemType<MechanicalBow>(), 1);
            recipe.AddIngredient(ItemID.ShroomiteBar, 10);
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


            type = ModContent.ProjectileType<Projectiles.ExplosiveArrow>();

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}