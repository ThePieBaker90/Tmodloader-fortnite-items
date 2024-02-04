using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;
using FortniteItems.Content.Buffs;
using FortniteItems.Content.Projectiles;
using System.Threading;

namespace FortniteItems.Content.Items.Weapons
{
    public class ShockwaveHammer : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ShockwaveHammer";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shockwave Hammer");
            // Tooltip.SetDefault("Has a high knockback and damage but does not fire a projectile\n\"Personal Defense of the Ageless Champion\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        
        public override void SetDefaults()
        {

            Item.damage = 735;
            //when calamity comes out, this needs to be rebalanced 
            Item.DamageType = DamageClass.Melee;
            Item.width = 76;
            Item.height = 76;
            Item.useTime = 40;
            Item.useAnimation = 40;
            //Item.reuseDelay = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 20;
            Item.value = Item.sellPrice(gold: 24);
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
            Item.rare = ItemRarityID.Purple; //post moonlord
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.ArmorPenetration = 100;
            Item.crit = 46;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("ArmoredShell", out ModItem ArmoredShell) && calamityMod.TryFind("UnholyEssence", out ModItem UnholyEssence) && calamityMod.TryFind("GalacticaSingularity", out ModItem GalacticaSingularity))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ArmoredShell.Type, 2);
                recipe.AddIngredient(UnholyEssence.Type, 8);
                recipe.AddIngredient(GalacticaSingularity.Type, 1);
                recipe.AddIngredient(ItemID.LargeAmethyst, 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds Recipe
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.LunarBar, 12);
                recipe.AddIngredient(ItemID.LargeAmethyst, 1);
                recipe.AddIngredient(ItemID.Pwnhammer, 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                if (!player.HasBuff<KineticCooldown>())
                {
                    Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<ShockwaveHammerLaunch>(), damage, knockback, player.whoAmI);
                    player.AddBuff(ModContent.BuffType<KineticCooldown>(), 180); //3 Seconds
                }
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, -9f);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

    }
}
