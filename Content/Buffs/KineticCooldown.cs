using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class KineticCooldown : ModBuff
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/KineticCooldown";
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}

