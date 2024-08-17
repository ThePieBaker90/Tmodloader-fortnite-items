using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace FortniteItems.Content.Projectiles
{
    public class VGrenade : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vindertech Grenade"); //The English name of the projectile
        }

        int TickSinceCreation = 0;

        public override void SetDefaults()
        {

                Projectile.width = 16; //The width of projectile hitbox
                Projectile.height = 26; //The height of projectile hitbox
                Projectile.aiStyle = 16; //The ai style of the projectile, please reference the source code of Terraria
                Projectile.friendly = true; //Can the projectile deal damage to enemies?
                Projectile.hostile = false; //Can the projectile deal damage to the player?
                Projectile.DamageType = DamageClass.Ranged; //Is the projectile shoot by a ranged weapon?
                Projectile.ignoreWater = false; //Does the projectile's speed be influenced by water?
                Projectile.tileCollide = true; //Can the projectile collide with tiles?\
                Projectile.timeLeft = 360; // 6 Seconds
                Projectile.velocity = new Vector2();

                AIType = ProjectileID.Bomb; //Act exactly like default grenade
            


        }
        public override void AI()
        {
            base.AI();
            if(TickSinceCreation >= 180 && Projectile.velocity.Y == (float)0.2)//Checking if the projectile has an exact vertical velocity.
            {
                Projectile.timeLeft = 1;
            }
            TickSinceCreation++;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            position.Y -= 52;
            Vector2 Zero = new Vector2(0, 0);
            SoundEngine.PlaySound(new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/GrenadeExplosion")
            {
                Volume = 0.2f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            });
            if (Main.myPlayer == Projectile.owner)
            {
                Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.78f);
                var projectile = Projectile.NewProjectileDirect(Terraria.Entity.InheritSource(Projectile), position, Zero, ProjectileID.DD2ExplosiveTrapT3Explosion, 100, 10, Main.myPlayer);
            }
           
            
            
            

            //int radius = 40;
            //for (int x = -radius; x <= radius; x++)
            //{
            //	for (int y = -radius; y <= radius; y++)
            //	{
            //		int xPosition = (int)(x + position.X / 64.0f);
            //		int yPosition = (int)(y + position.Y / 64.0f);
            //
            //		if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
            //		{
            //			if (Main.rand.NextBool(10))
            //			{
            //              Dust.NewDust(position, 16, 16, DustID.Smoke, 0f, 0f, 120, new Color(), 1f);
            //			}
            //		}
            //	}
            //}

        }
    }
}