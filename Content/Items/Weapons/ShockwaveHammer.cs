using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

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
            Item.DamageType = DamageClass.Melee;
            Item.width = 76;
            Item.height = 76;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 20;
            Item.value = Item.sellPrice(gold: 24);
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("Turquoise", out ModRarity Turquoise))
            {
                Item.rare = Turquoise.Type; //Post stormweaver
            }
            else
            {
                Item.rare = -11; //Amber Rarity as this weapon is unobtainable without calamity
            }
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.ArmorPenetration = 100;
            Item.crit = 92;
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
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, -9f);
        }

    }
}
