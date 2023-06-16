using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using System;
using System.Reflection.PortableExecutable;
using Terraria.DataStructures;
using System.Transactions;

namespace FortniteItems.Content.Items.Weapons
{
    public class SidearmPistol : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/SidearmPistol";
        //A set of variables which determine the stats at full life and the stats at crit life (30% life and below)
        //If these werent here, multiple variables would need to be changed rather than just one.
        int fullLifeDmg = 20;
        int critLifeDmg = 25;
        int fullLifeUse = 12;
        int critLifeUse = 10;
        int fullLifeSpeed = 15;
        int critLifeSpeed = 20;
        float fullLifeKnock = 0.1f;
        float critLifeKnock = 1;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sidearm Pistol");
            // Tooltip.SetDefault("40% chance to not use ammo\nGains a stat buff when the user is below 30% health\n\"New and improved from chapter 3!\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //an early game pistol
        public override void SetDefaults()
        {

            Item.damage = fullLifeDmg;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = fullLifeUse;
            Item.useAnimation = fullLifeUse;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = fullLifeKnock;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Blue; //Post WOF
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/PistolShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = fullLifeSpeed;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Pistol>(), 1);
            recipe.AddRecipeGroup(nameof(ItemID.CobaltBar), 12);
            recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            double doubleStatLife = player.statLife;
            double doubleStatLifeMax = player.statLifeMax;
            double lifeRatio = doubleStatLife / doubleStatLifeMax;
            if (lifeRatio <= 0.3)
            {
                damage = critLifeDmg;
                knockback = critLifeKnock;
                Item.useTime = critLifeUse;
                Item.useAnimation = critLifeUse;
                Item.shootSpeed = critLifeSpeed;
            }
            else
            {
                damage = fullLifeDmg;
                knockback = fullLifeKnock;
                Item.useTime = fullLifeUse;
                Item.useAnimation = fullLifeUse;
                Item.shootSpeed = fullLifeSpeed;
            }


        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.40f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}