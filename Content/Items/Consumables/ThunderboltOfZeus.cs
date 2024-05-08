using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using FortniteItems.Content.Items.Weapons;

namespace FortniteItems.Content.Items.Consumables
{
    public class ThunderboltOfZeus : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ThunderboltOfZeus";
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {

            Item.damage = 80;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.reuseDelay = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.sellPrice(copper: 50);
            Item.value = Item.buyPrice(silver: 5);
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ThunderboltOfZeus>();
            Item.shootSpeed = 30;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.ArmorPenetration = 25;
            Item.consumable = false;
            Item.maxStack = 1;
            
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }

        /*
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NimbusRod, 1);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftShotgun>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        */


    }
}
