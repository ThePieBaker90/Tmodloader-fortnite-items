using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class TacticalSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tactical Submachine Gun");
            Tooltip.SetDefault("20% chance to not consume ammo\n\"Looks a bit... different\"");
            //uses the OLD OLD OLD smg model that was present at game launch as the tactical smg model is already use by the makeshift smg
            //and fits better as a makeshift weapon than as a tactical weapon
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game rifle that is outclassed by nearly every other rifle in the game and is mainly used as a material
        public override void SetDefaults()
        {

            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Orange; //Early prehardmode crafted with demonite(or crimtane)
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/MakeshiftSMGShoot")
            {
                Volume = 0.4f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("BloodSample", out ModItem BloodSample) && calamityMod.TryFind("RottenMatter", out ModItem RottenMatter))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.DemoniteBar, 8);
                recipe.AddIngredient(RottenMatter.Type, 10);
                recipe.AddIngredient(ModContent.ItemType<MakeshiftSMG>());
                recipe.AddTile(TileID.Anvils);
                recipe.Register();

                Recipe recipe2 = CreateRecipe();
                recipe2.AddIngredient(ItemID.CrimtaneBar, 8);
                recipe2.AddIngredient(BloodSample.Type, 10);
                recipe2.AddIngredient(ModContent.ItemType<MakeshiftSMG>());
                recipe2.AddTile(TileID.Anvils);
                recipe2.Register();
            }
            else
            {
                Recipe recipe3 = CreateRecipe();
                recipe3.AddRecipeGroup(nameof(ItemID.GoldBar), 12);
                recipe3.AddIngredient(ItemID.Ruler, 1);
                recipe3.AddIngredient(ModContent.ItemType<MakeshiftSMG>());
                recipe3.AddTile(TileID.TinkerersWorkbench);
                recipe3.Register();
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4)); //Random Bullet Spread

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.20f;
        }

    }
}