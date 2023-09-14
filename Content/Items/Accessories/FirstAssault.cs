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
    public class FirstAssault : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FirstAssault";

        public static int timer = 180;
        public static bool effectsPlayed = false;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Lime; //shroomite craft
            Item.value = Item.sellPrice(gold: 5);
            Item.accessory = true;
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //check to see that we are looking at the wearer
            if (player.whoAmI == Main.myPlayer)
            {
                //if the timer is complete we give a damage bonus to items in the assault class
                if (timer <= 0)
                {
                    player.GetDamage(ModContent.GetInstance<AssaultRifleClass>()) *= 1.50f;
                }
                if (player.controlUseItem)
                {
                    effectsPlayed = false;
                    timer = 180;//3 second timer
                }

            }

            if (timer > 0)
            {
                timer--;
            }

            if(timer == 0 && effectsPlayed == false)
            {
                effectsPlayed = true;
                SoundEngine.PlaySound(SoundID.Item149);
                
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddIngredient(ItemID.Stopwatch, 1);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftAR>());
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();

        }

    }
}
