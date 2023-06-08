using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class OtherworldlyGravity : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Otherworldly Gravity");
            // Description.SetDefault("Gravity is greatly reduced!");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.gravity *= 0.2f;
            player.jumpSpeedBoost *= 1.2f;
            player.noFallDmg = true;
        }
    }
}