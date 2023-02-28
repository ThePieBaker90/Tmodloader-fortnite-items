using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Buffs
{
    public class SlappedUp : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slapped Up");
            Description.SetDefault("75% increased movement speed");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.maxRunSpeed *= 1.75f;
        }
    }
}