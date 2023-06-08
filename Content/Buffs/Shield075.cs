using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class Shield075 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("75% Shield");
            // Description.SetDefault("Grants 30 defense.");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 30;
        }
    }
}