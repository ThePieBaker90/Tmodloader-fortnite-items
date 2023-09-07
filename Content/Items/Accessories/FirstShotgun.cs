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

namespace FortniteItems.Content.Items.Accessories
{
    public class FirstShotgun : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/LastShots";

        public static int timer = 180;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //check to see that we are looking at the wearer
            if (player.whoAmI == Main.myPlayer)
            {
                //checks every slot in the inventory
                foreach (Item item in player.inventory)
                {
                    //if the timer is complete we give a damage bonus to items ending with shotgun
                    if (timer <= 0)
                    {
                        if (item.Name.EndsWith("Shotgun") || item.Name.EndsWith("shotgun"))
                        {
                            player.GetDamage(DamageClass.Generic) += 0.05f;
                            
                        }
                    }
                }
                if (player.controlUseItem)
                {
                    timer = 180;//3 second timer
                }

            }

            if (timer > 0)
            {
                timer--;
            }

        }



    }
}
