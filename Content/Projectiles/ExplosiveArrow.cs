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
    public class ExplosiveArrow : ModProjectile
    {
        int numBombs = 3;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 8; // The width of projectile hitbox
            Projectile.height = 8; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.WoodenArrowFriendly; // Act exactly like default Bullet
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = Projectile.Center;

            if (Main.myPlayer == Projectile.owner)
            {
                Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.78f);
                
                
                for(int i = 0; i < numBombs;  i++)
                {
                    ExplosiveSpawn(position, Projectile.velocity);
                }
                
            }
        }

        public void ExplosiveSpawn(Vector2 position, Vector2 velocityOfProjectile)
        {
            Random random = new Random();
            Vector2 safeVector = new Vector2(1, 1);
            Vector2 normalizedVector = velocityOfProjectile.SafeNormalize(safeVector);
            var projectile = Projectile.NewProjectileDirect(Terraria.Entity.InheritSource(Projectile), position, -(normalizedVector.RotatedByRandom(MathHelper.ToRadians(180))), ModContent.ProjectileType<Projectiles.DynamitePiece>(), 0, 0, Main.myPlayer);
            projectile.timeLeft = random.Next(10,61);
            projectile.damage = 0;
        }
    }
}