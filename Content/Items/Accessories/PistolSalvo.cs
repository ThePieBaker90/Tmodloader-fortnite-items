using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Items.Weapons;
using System;
using Terraria.DataStructures;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Accessories
{
    public class PistolSalvo : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/PistolSalvo";

        public override void SetStaticDefaults()
        {

            /* Name: 
             *  Pistol Salvo
             * 
             * Description: 
             *  45% increased damage on pistols, but 10% slower firing speed
             * 
             * Obtain Point:
             *  Post Skeletron Craft
             *  
             * Intent:
             *  Accessory which increases damage for pistol class items but slightly decreases firing speed.
             *  Useful for piercing high defense targets but harmful when attacking targets with extremely high defense.
             */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue; //Augment
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 1);
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<PistolClass>()) *= 1.45f;
            player.GetAttackSpeed(ModContent.GetInstance<PistolClass>()) *= 0.90f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftPistol>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }


    }
}
