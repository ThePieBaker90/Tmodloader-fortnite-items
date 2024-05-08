using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace FortniteItems.Content.Projectiles
{
    public class ThunderboltOfZeus : ModProjectile
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ThunderboltOfZeusProj";

        public override void SetStaticDefaults()
        {
            
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {

            Projectile.width = 26; //The width of projectile hitbox
            Projectile.height = 26; //The height of projectile hitbox
            Projectile.aiStyle = 1; //The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; //Can the projectile deal damage to enemies?
            Projectile.hostile = false; //Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; //Is the projectile shoot by a ranged weapon?
            Projectile.ignoreWater = false; //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; //Can the projectile collide with tiles?\
            Projectile.velocity = new Vector2();
            Projectile.timeLeft = 60;
            AIType = ProjectileID.Bullet;
            Projectile.extraUpdates = 1;


        }

        public override void AI()
        {
            base.AI();
        }

        public override void Kill(int timeLeft)
        {
            Random random = new Random();
            Vector2 position = Projectile.Center;
            
            SoundEngine.PlaySound(SoundID.DD2_LightningAuraZap);
            
            if (Main.myPlayer == Projectile.owner)
            {
                Lighting.AddLight(Projectile.Center, Color.Blue.ToVector3() * 0.78f);
                for (int i = 0; i < 12; i++)
                {
                    Vector2 baseVector = new Vector2(2, 0);
                    Vector2 rotatedVector = baseVector.RotatedBy(MathHelper.ToRadians(30)*i);
                    var projectile = Projectile.NewProjectileDirect(Terraria.Entity.InheritSource(Projectile), position, rotatedVector, ProjectileID.ThunderStaffShot, 8, 1, Main.myPlayer);
                    projectile.friendly = true;
                    projectile.hostile = false;
                    projectile.penetrate = 2;
                }
                
            }

        }
    }
}