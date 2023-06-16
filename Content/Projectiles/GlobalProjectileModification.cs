using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FortniteItems.Content.NPCs;

namespace FortniteItems.Content.Projectiles
{
    // Here is a class dedicated to showcasing projectile modifications
    public class GlobalProjectileModification : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        
        public bool sayTimesHitOnThirdHit;
        // These are set when the user specifies that they want a trail.
        private Color trailColor;
        private bool trailActive;

        private int buffToApply;
        private int buffTime;
        public bool applyBuffOnHitActive;

        // Here, a method is provided for setting the above fields.
        public void SetTrail(Color color)
        {
            trailColor = color;
            trailActive = true;
        }

        public void applyBuffOnHit(int buff, int time)
        {
            buffToApply = buff;
            buffTime = time;
            applyBuffOnHitActive = true;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            //Debug Tool
            if (sayTimesHitOnThirdHit)
            {
                ProjectileModificationGlobalNPC globalNPC = target.GetGlobalNPC<ProjectileModificationGlobalNPC>();
                if (globalNPC.timesHitByModifiedProjectiles % 3 == 0)
                {
                    Main.NewText($"This NPC has been hit with a modified projectile {globalNPC.timesHitByModifiedProjectiles} times.");
                }
                target.GetGlobalNPC<ProjectileModificationGlobalNPC>().timesHitByModifiedProjectiles += 1;
            }

            //Allows us to apply an effect upon projectile hit
            if (applyBuffOnHitActive)
            {
                target.AddBuff(buffToApply, buffTime);
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (trailActive)
            {
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.TintableDustLighted, default, default, default, trailColor);
            }
        }
    }
}