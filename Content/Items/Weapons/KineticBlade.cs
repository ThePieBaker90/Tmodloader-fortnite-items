using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;
using FortniteItems.Content.Projectiles;
using FortniteItems.Content.Buffs;

namespace FortniteItems.Content.Items.Weapons
{
    public class KineticBlade : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/KineticBlade";
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        
        public override void SetDefaults()
        {

            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.width = 76;
            Item.height = 76;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow; //Post All Mechs
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.ArmorPenetration = 100;
            Item.crit = 11;
            Item.shootSpeed = 15;
            Item.shoot = ProjectileID.PurificationPowder;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, -9f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                if (!player.HasBuff<KineticCooldown>())
                {
                    Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<KineticBladeTeleport>(), damage, knockback, player.whoAmI);
                    player.AddBuff(ModContent.BuffType<KineticCooldown>(), 240); //4 Seconds
                }
            }
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
    }
}
