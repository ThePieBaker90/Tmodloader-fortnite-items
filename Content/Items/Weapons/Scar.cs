using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class Scar : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/Scar";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Assault Rifle");
            // Tooltip.SetDefault("25% chance to not consume ammo\n\"Gotta get that W\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a hardmode rifle that is a long range alternative to the mega shark
        public override void SetDefaults()
        {

            Item.damage = 8;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(gold: 1, silver: 50);
            Item.rare = ItemRarityID.Green; //Goblin Army 
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 7;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
            recipe.AddIngredient(ItemID.SpikyBall, 25);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<MakeshiftAR>(), 1);
            recipe2.AddIngredient(ItemID.SpikyBall, 25);
            recipe2.AddIngredient(ItemID.PlatinumBar, 12);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<Scar>(), 1);
            recipe3.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe3.AddTile(TileID.TinkerersWorkbench);
            recipe3.Register();

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
            return Main.rand.NextFloat() >= 0.25f;
        }

    }
}