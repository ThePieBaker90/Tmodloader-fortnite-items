using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using FortniteItems.Content.Projectiles;
using FortniteItems.Content.Buffs;

namespace FortniteItems.Content.Items.Pets
{
    public class TestPetItem : ModItem
    {
        //Code originates from https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Pets/ExamplePet/ExamplePetItem.cs
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/SleekMechanicalParts";

        // Names and descriptions of all ExamplePetX classes are defined using .hjson files in the Localization folder
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish); // Copy the Defaults of the Zephyr Fish Item.

            Item.shoot = ModContent.ProjectileType<TestPetProjectile>(); // "Shoot" your pet projectile.
            Item.buffType = ModContent.BuffType<TestPetBuff>(); // Apply buff upon usage of the Item.
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }

    }
}
