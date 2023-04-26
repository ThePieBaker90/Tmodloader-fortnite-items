using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Buffs
{
    public class OtherworldlyGravity : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Otherworldly Gravity");
            Description.SetDefault("75% increased movement speed");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.gravity *= 0.2f;
        }
    }
}