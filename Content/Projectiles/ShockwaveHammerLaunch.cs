using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rail;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;
using FortniteItems.Assets.Methods;
using Mono.Cecil;
using static Terraria.ModLoader.ExtraJump;
using Microsoft.CodeAnalysis;


namespace FortniteItems.Content.Projectiles
{
    public class ShockwaveHammerLaunch : ModProjectile
    {
        Vector2[] oldPositionArray = new Vector2[31];
        int tick = 0;
        public override string Texture => $"{nameof(FortniteItems)}/Content/Projectiles/ChargeShotgunProjectile";
        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.damage = 0;
            Projectile.penetrate = -1;
            Projectile.width = 0; // The width of projectile hitbox
            Projectile.height = 0; // The height of projectile hitbox
            Projectile.aiStyle = 0; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = false; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 40; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0;
            Projectile.knockBack = 0;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position;
            base.AI();
        }

        public override void Kill(int timeLeft)
        {
            //Setting up variables
            
            SoundStyle shockwaveHammerLaunch = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ShockwaveHammerLaunch")
            {
                Volume = 0.1f,
                PitchVariance = 0.4f,
                MaxInstances = 1,
            };
            
            Player player = Main.player[Projectile.owner];
           

            //Launches the player upwards
            player.velocity.Y -= 25;
            //Player is facing to the left
            if (player.direction == -1)
            {
                //Launches the player to the left
                player.velocity.X -= 10;
            }
            //Player is facing to the right
            else if (player.direction == 1)
            {
                //Launches the player to the right
                player.velocity.X += 10;
            }
            SoundEngine.PlaySound(shockwaveHammerLaunch);
            Console.WriteLine("Shockwave Sound Played");
        }

    }
}