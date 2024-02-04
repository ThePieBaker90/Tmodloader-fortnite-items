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
    public class KineticBladeTeleport : ModProjectile
    {
        Vector2[] oldPositionArray = new Vector2[31];
        int tick = 0;
        public override string Texture => $"{nameof(FortniteItems)}/Content/Projectiles/ChargeShotgunProjectile";
        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.damage = 100;
            Projectile.penetrate = -1;
            Projectile.width = player.width; // The width of projectile hitbox
            Projectile.height = player.height - 10; // The height of projectile hitbox
            Projectile.aiStyle = 0; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 30; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 8; // SHOULD BE 8
            Projectile.knockBack = 5;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Setting up variables
            Player player = Main.player[Projectile.owner];

            //we never want the tick to be outside of the array, so we see if tick is 0, if it isnt, we take the current tick and subtract 1.
            //We subtract 1 because if we were to reference the most recent tick (which pastTick lines up with currently) we would reference part
            //of the array that hasn't been written to.
            int pastTick = tick;
            if (tick > 0)
            {
                pastTick = tick - 1;
            }

            //this tells the while loop to stop if we have found a suitable place
            bool posFound = false;

            //This iterates backwards through the array to find a suitable spot to put the player
            while (!posFound)
            {
                //We see if the current position held in the array at pastTick does not have any collision which would collide with the player's current size
                if (!Collision.SolidCollision(oldPositionArray[pastTick], player.width, player.height-10) && pastTick > 0)
                {
                    //If it doesn't we have found our spot, we teleport the projectile to that position and set posFound to true so we exit the while loop
                    Projectile.position = oldPositionArray[pastTick];
                    posFound = true;
                }
                //If there is collision preventing the player, we check if pastTick is greater than 0, if it is then we have not reached the beginning of the array and can
                //Step to the position before this one
                else if(pastTick > 0)
                {
                    pastTick--;
                }
                //Otherwise we know it is 0 and we are at the end of the array, since we have not exited the while loop we know there is no valid spots to place the player,
                //So we teleport the projectile to their position, this will cause them to teleport nowhere as a failsafe
                else
                {
                    Projectile.position = player.position;
                    posFound = true;
                }
                
            }
            //We then kill the projectile which will cause all of the kill code to be run
            Projectile.Kill();
            //and return false to not kill the projectile normally, killing it normally causes the player to be able to clip when spamming or firing this projectile at certain angles
            return false;
        }

        public override void AI()
        {
            SpawnDashDust();

            oldPositionArray[tick] = Projectile.Center;
            tick++;

            base.AI();
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            player.Teleport(Projectile.Center, 6);
            //Teleport Style 6 has special effects

        }


        public void SpawnDashDust()
        {
            //Dust logic
            Color purpleDash = new Color(0, 0, 0);

            for (int i = 0; i < 4; i++)
            {

                int DustID = Dust.NewDust(Projectile.position, Projectile.width + 2, Projectile.height + 2, 21, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, purpleDash, 1f);
                //Dust 21 is vile powder
                Main.dust[DustID].noGravity = false;
                Main.dust[DustID].scale *= 1.75f;
            }
        }

    }
}