using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace FortniteItems.Projectiles
{
    public class ChargeShotgunProjectile : ModProjectile
    {
        bool misfire = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charge Shotgun Projectile"); // The English name of the projectile

            
        }

        public override void SetDefaults()
        {
            Projectile.width = 0; // The width of projectile hitbox
            Projectile.height = 0; // The height of projectile hitbox
            Projectile.aiStyle = 0; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = false; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 420; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0; // How much light emit around the projectile
            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame
        }

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);

        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position;
            if (!player.controlUseItem)
            {
                misfire = false;
                Projectile.timeLeft = 1;
            }
            base.AI();
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 playerPosition = player.VisualPosition; 
            float ProjectileX = playerPosition.X - Main.MouseWorld.X;
            float ProjectileY = playerPosition.Y - Main.MouseWorld.Y;
            //using kinematics we can create a 2d vector with an initial position and the final position, since accelleration is constant
            //we can also determine that velocity will be constant. The formula Y(o)-Y(f)/X(o)-X(f) gives us the velocity, o is initial and f is final position

           
            Vector2 velocity = new Vector2(-ProjectileX,-ProjectileY);
            Vector2 rotatedVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
            /*+,+ is bottom right
             *-,- is top left 
             *-,+ is bottom left
             *+,- is top right
             */

            Vector2 position = Projectile.Center;
            var projectile = Projectile.NewProjectileDirect(Projectile.InheritSource(Projectile), position, rotatedVelocity, ProjectileID.MeteorShot, 40, 10, Main.myPlayer);
            SoundStyle shootSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/PumpShotgunShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            SoundStyle misfireSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/SuppressedPistolShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            };
            if (misfire == false)
            {
                SoundEngine.PlaySound(shootSound);
            }
            else if(misfire == true)
            {
                SoundEngine.PlaySound();
            }
            
        }
    }
}