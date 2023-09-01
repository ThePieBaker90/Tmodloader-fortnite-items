using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

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
        //Intended to be an early game upgrade to the Minishark
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
            //Item.shoot = ProjectileID.DeathSickle;
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

        /*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {
            const int NumProjectiles = 3; // The humber of projectiles that this gun will shoot.

            type = ProjectileID.DeathSickle;

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        */

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, -9f);
        }

    }
}
