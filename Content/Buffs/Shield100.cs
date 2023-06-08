using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class Shield100 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("100% Shield");
            // Description.SetDefault("Grants 40 defense.");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 40; // Grant a +4 defense boost to the player while the buff is active.
        }
    }
}