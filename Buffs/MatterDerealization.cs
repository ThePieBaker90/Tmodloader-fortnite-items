using IL.Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Buffs
{
    public class MatterDerealization : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Matter Derealized");
            Description.SetDefault("Your matter is spread across countless realities! Zero Point Blinking is Disabled");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
        }
    }
}

