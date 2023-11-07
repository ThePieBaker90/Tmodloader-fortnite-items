using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FortniteItems.Content.Projectiles
{
    public class RailGunProjectile : ModProjectile
    {
        //This code is adapted from https://forums.terraria.org/index.php?threads/requesting-channelled-weapon-code.51356/ by Sin Costan 

        public override string Texture => $"{nameof(FortniteItems)}/Content/Projectiles/ChargeShotgunProjectile";
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.timeLeft = 180;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 100; 
            Projectile.penetrate = -1;
        }
        

        public override void AI()
        {
            //Projectile appears at 4 ticks
            if (Projectile.ai[0] > 4f)
            {
                Color redLazer = new Color(255, 0, 0);

                for (int i = 0; i < 4; i++)
                {

                    int DustID = Dust.NewDust(Projectile.position, Projectile.width + 2, Projectile.height + 2, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, redLazer, 1f);
                    //Dust 60 is red torch
                    Main.dust[DustID].noGravity = true;
                    Main.dust[DustID].scale *= 1.75f;
                }
            }
            Projectile.ai[0] += 1f;
        }
    }
}