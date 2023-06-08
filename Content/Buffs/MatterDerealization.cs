using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class MatterDerealization : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Matter Derealized");
            // Description.SetDefault("Your matter is spread across countless realities! Zero Point Blinking is Disabled");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}

