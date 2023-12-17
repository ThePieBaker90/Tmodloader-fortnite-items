using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using FortniteItems.Content.Projectiles;

namespace FortniteItems.Content.Buffs
{
    public class TestPetBuff : ModBuff
    {
        //Code originates from https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Pets/ExamplePet/ExamplePetBuff.cs
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        { // This method gets called every frame your buff is active on your player.
            bool unused = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<TestPetProjectile>());
        }
    }
}
