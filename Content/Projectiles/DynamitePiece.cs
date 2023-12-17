using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace FortniteItems.Content.Projectiles
{
    public class DynamitePiece : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            //Used as the projectiles spawned from the explosive arrow
        }

        public override void SetDefaults()
        {
            AIType = ProjectileID.Bomb; //Act exactly like default grenade
            Projectile.width = 16; //The width of projectile hitbox
            Projectile.height = 16; //The height of projectile hitbox
            Projectile.aiStyle = 16; //The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; //Can the projectile deal damage to enemies?
            Projectile.hostile = false; //Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; //Is the projectile shoot by a ranged weapon?
            Projectile.ignoreWater = false; //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; //Can the projectile collide with tiles?\
            Projectile.timeLeft = 100;
            Projectile.velocity = new Vector2();
            Projectile.damage = 1;

            



        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            Vector2 Zero = new Vector2(0, 0);
            if (Main.myPlayer == Projectile.owner)
            {
                
                var projectile = Projectile.NewProjectileDirect(Terraria.Entity.InheritSource(Projectile), position, Zero, ProjectileID.Grenade, 0, 0, Main.myPlayer);
                projectile.timeLeft = 0;
                projectile.damage = 0;
                projectile.hostile = false;
                
            }

        }
    }
}