using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Weapons
{
    public class LeverActionRifle : ModItem
    {

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/LeverActionRifle";

        public override void SetStaticDefaults()
        {


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post EoC sniper rifle
        public override void SetDefaults()
        {

            Item.damage = 44;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 50;
            Item.useAnimation = 48;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green; //Post EoC Craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/LeverActionShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 200;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 30;
            Item.crit = 10;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.BlackLens, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.AddDecraftCondition(Condition.CrimsonWorld);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.DemoniteBar, 10);
            recipe2.AddIngredient(ItemID.BlackLens, 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddDecraftCondition(Condition.CorruptWorld);
            recipe2.Register();

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

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}