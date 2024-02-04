﻿using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class MatterDerealization : ModBuff
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MatterDerealization";
        public override void SetStaticDefaults()
        {
            
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}

