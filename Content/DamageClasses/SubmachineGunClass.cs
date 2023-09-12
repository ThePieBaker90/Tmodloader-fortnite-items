using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FortniteItems.Content.DamageClasses
{
    public class SubmachineGunClass : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Ranged)
            {
                return StatInheritanceData.Full;
            }

            return StatInheritanceData.None;
        }
        public override void SetDefaultStats(Player player)
        {
            player.GetCritChance<SubmachineGunClass>() += 4;
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Ranged)
            {
                return true;
            }
            return false;
        }

        public override bool UseStandardCritCalcs => true;
    }
}
