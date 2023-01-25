using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class PrimalFlameBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primal Flame Bow");
            Tooltip.SetDefault("Shoots arrows at a high velocity\nChanges Wooden Arrows into Primal Flame Arrows\n\"Like a long range firefly jar!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            Item.damage = 112;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow; //Post All Mechs
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.crit = 16;
            Item.ArmorPenetration = 20;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("EssenceofChaos", out ModItem EssenceofChaos) && calamityMod.TryFind("UnholyCore", out ModItem UnholyCore) && calamityMod.TryFind("Brimlance", out ModItem Brimlance)
                && calamityMod.TryFind("SeethingDischarge", out ModItem SeethingDischarge) && calamityMod.TryFind("DormantBrimseeker", out ModItem DormantBrimseeker))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<PrimalBow>(), 1);
                recipe.AddIngredient(EssenceofChaos.Type, 4);
                recipe.AddIngredient(UnholyCore.Type, 5);
                recipe.AddIngredient(Brimlance.Type, 1);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                Recipe recipe2 = CreateRecipe();
                recipe2.AddIngredient(ModContent.ItemType<PrimalBow>(), 1);
                recipe2.AddIngredient(EssenceofChaos.Type, 4);
                recipe2.AddIngredient(UnholyCore.Type, 5);
                recipe2.AddIngredient(SeethingDischarge.Type, 1);
                recipe2.AddTile(TileID.AdamantiteForge);
                recipe2.Register();

                Recipe recipe3 = CreateRecipe();
                recipe3.AddIngredient(ModContent.ItemType<PrimalBow>(), 1);
                recipe3.AddIngredient(EssenceofChaos.Type, 4);
                recipe3.AddIngredient(UnholyCore.Type, 5);
                recipe3.AddIngredient(DormantBrimseeker.Type, 1);
                recipe3.AddTile(TileID.AdamantiteForge);
                recipe3.Register();
            }//Adds recipe if calamity mod is installed
            else
            {
                Recipe recipe4 = CreateRecipe();
                recipe4.AddIngredient(ItemID.ChlorophyteBar, 10);
                recipe4.AddIngredient(ItemID.MolotovCocktail, 1);
                recipe4.AddIngredient(ItemID.Firefly, 3);
                recipe4.AddIngredient(ModContent.ItemType<PrimalBow>(), 1);
                recipe4.AddTile(TileID.AdamantiteForge);
                recipe4.Register();

            }
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
                type = ModContent.ProjectileType<Projectiles.FlameArrow>();
            }

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }
    }
}
