using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FortniteItems.Content.Projectiles
{
    public class AntiReflectionBullet : ModProjectile
    {
        public override string Texture => $"{nameof(FortniteItems)}/Content/Projectiles/PrimalBullet";

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 8; // The width of projectile hitbox
            Projectile.height = 8; // The height of projectile hitbox

            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like a bullet
            Projectile.aiStyle = 27; // The ai style of the projectile, please reference the source code of Terraria
            /*
             * to avoid reflection we must have our projectile be not any of the following ai types
             * 1 = Bullets, Arrows, & Lasers
             * 2 = Thrown Items such as the shuriken & bone
             * 8 = Bouncing Projectiles such as the water bolt or ball of fire
             * 21 = Magical Notes from the harp
             * 24 = Crystal Projectiles
             * 28 = Frosty dust based projectiles
             * 29 = Projectiles from the gem staffs
             * 131 = Flameburst tower projectiles
             * 
             */
        }


        public override void Kill(int timeLeft)
        {
            Console.WriteLine("AI Style: " + Projectile.aiStyle + " |Type: " + Projectile.type + " |Reflected Result: " + Projectile.CanBeReflected());
            
        }
    }
}