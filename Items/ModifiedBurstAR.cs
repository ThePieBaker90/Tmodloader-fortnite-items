using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class ModifiedBurstAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Modified Burst Assault Rifle");
            Tooltip.SetDefault("Shoots in random bursts\n\"Gotta give them that L, with 1 to 7 shots at a time\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post evil boss rifle intended for early game sustained damage
        public override void SetDefaults()
        {

            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.2f;
            Item.value = Item.sellPrice(silver: 40);
            Item.rare = ItemRarityID.Green; //Mid Pre Hardmode Craft from Meteorite
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot0")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 70;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 30;
            Item.reuseDelay = 10;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BurstAR>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.5f)); //Random Bullet Spread
            int randomValue = Main.rand.Next(7);
            switch (randomValue)
            {
                    case 0:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot0")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 40;//1 shot
                    break;
                    case 1:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot1")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 20;//2 shots
                    break;
                    case 2:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot2")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 13;//3 shots //Not exact
                    break;
                    case 3:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot3")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 10;//4 shots
                    break;
                    case 4:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot4")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 8;//5 shots
                    break;
                    case 5:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot5")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 6;//6 shots //not exact
                    break;
                    case 6:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot6")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 5;//7 shots //not exact
                    break;
                    default:
                    Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/ModifiedBurstARShoot0")
                    {
                        Volume = 0.9f,
                        PitchVariance = 0.2f,
                        MaxInstances = 3,
                    };
                    Item.useTime = 40;
                    break;



            }
        }


    }
}