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
    public class FirstShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/FirstShotgun";

        public static int timer = 180;
        public static bool effectsPlayed = false;

        public override void SetStaticDefaults()
        {
            /* Name: 
             *  First Shotgun
             * 
             * Description: 
             *  50% increased damage on shotguns after not firing for 3 seconds
             *  For weapons that fire in a burst, only the first shot has a damage increase
             * 
             * Obtain Point:
             *  Pre Boss Craft
             *  
             * Intent:
             *  Accessory which increases damage for shotgun class items when the user has laid in wait.
             *  Useful for first shots but less useless for succesive shots.
             */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue; //Augment
            Item.value = Item.sellPrice(gold: 1);
            Item.accessory = true;
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //check to see that we are looking at the wearer
            if (player.whoAmI == Main.myPlayer)
            {
                //if the timer is complete we give a damage bonus to items in the shotgun class
                if (timer <= 0)
                {
                    player.GetDamage(ModContent.GetInstance<ShotgunClass>()) *= 1.50f;
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
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.Stopwatch, 1);
            recipe.AddIngredient(ModContent.ItemType<MakeshiftShotgun>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }

    }
}
