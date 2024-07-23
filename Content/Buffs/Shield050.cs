using Terraria;
using Terraria.ModLoader;

namespace FortniteItems.Content.Buffs
{
    public class Shield050 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("50% Shield");
            // Description.SetDefault("Grants 20 defense.");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(ModContent.BuffType<Shield075>()) || player.HasBuff(ModContent.BuffType<Shield100>()))
            {
                player.DelBuff(buffIndex);
            }
            player.statDefense += 20;
        }
    }
}