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

/* This was originally going to be used on this weapon, but I decided it would go better with a modified weapon 
 * as those are more wacky concepts rather than the normal weapons which should be somewhat like the weapon
 * this will likely be the Modified Scoped AR's Functionality
 * //If player has pets (Induvidual effects are tied to each pet)
            if (player.HasBuff(BuffID.BabyDinosaur))
            {
                type = ProjectileID.PoisonFang;
            }
            else if (player.HasBuff(BuffID.BabyEater))
            {
                type = ProjectileID.CursedDart;
            }
            else if (player.HasBuff(BuffID.BabyFaceMonster))
            {
                type = ProjectileID.IchorDart;
            }
            else if (player.HasBuff(BuffID.BabyGrinch))
            {
                type = ProjectileID.OrnamentFriendly;
            }
            else if (player.HasBuff(BuffID.BabyHornet))
            {
                type = ProjectileID.Bee;
            }
            else if (player.HasBuff(BuffID.BabyImp))
            {
                type = ProjectileID.Flamelash;
            }
            else if (player.HasBuff(BuffID.BabyPenguin))
            {
                type = ProjectileID.IceBlock;
            }
            else if (player.HasBuff(BuffID.BabyRedPanda))
            {
                type = ProjectileID.Leaf;
            }
            else if (player.HasBuff(BuffID.BabySkeletronHead))
            {
                type = ProjectileID.MiniNukeMineI;
            }
            else if (player.HasBuff(BuffID.BabySnowman))
            {
                type = ProjectileID.ClusterSnowmanRocketI;
            }
            else if (player.HasBuff(BuffID.BabyTruffle))
            {
                type = ProjectileID.Mushroom;
            }
            else if (player.HasBuff(BuffID.BabyWerewolf))
            {
                type = ProjectileID.Stake;
            }
            else if (player.HasBuff(BuffID.BerniePet))
            {
                type = ProjectileID.PewMaticHornShot;
            }
            else if (player.HasBuff(BuffID.BlackCat))
            {
                type = ProjectileID.JackOLantern;
            }
            else if (player.HasBuff(BuffID.PetBunny))
            {
                type = ProjectileID.GoldenBullet;
            }
            else if (player.HasBuff(BuffID.ChesterPet))
            {
                type = ProjectileID.WeatherPainShot;
            }
            else if (player.HasBuff(BuffID.CompanionCube))
            {
                type = ProjectileID.BallofFire;
                //Did you just toss the Aperture Science Thing We Don't Know What It Does into the Aperture Science Emergency Intelligence Incinerator?
            }
            else if (player.HasBuff(BuffID.CursedSapling))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.DynamiteKitten))
            {
                type = ProjectileID.Grenade;
            }
            else if (player.HasBuff(BuffID.UpbeatStar))//Estee Buff
            {
                type = ProjectileID.FallingStar;
            }
            else if (player.HasBuff(BuffID.EyeballSpring))
            {
                type = ProjectileID.GreenLaser;
            }
            else if (player.HasBuff(BuffID.FennecFox))
            {
                type = ProjectileID.ThrowingKnife;
            }
            else if (player.HasBuff(BuffID.GlitteryButterfly))
            {
                type = ProjectileID.EighthNote;
            }
            else if (player.HasBuff(BuffID.GlommerPet))
            {
                type = ProjectileID.InsanityShadowFriendly;
            }
            else if (player.HasBuff(BuffID.PetDD2Dragon))//Hoardagron buff
            {
                type = ProjectileID.DD2PhoenixBowShot;
            }
            else if (player.HasBuff(BuffID.LilHarpy))
            {
                type = ProjectileID.Starfury;
            }
            else if (player.HasBuff(BuffID.PetLizard))
            {
                type = ProjectileID.PoisonedKnife;
            }
            else if (player.HasBuff(BuffID.MiniMinotaur))
            {
                type = ProjectileID.CrystalBullet;
            }
            else if (player.HasBuff(BuffID.PetParrot))
            {
                type = ProjectileID.CannonballFriendly;
            }
            else if (player.HasBuff(BuffID.PigPet))
            {
                type = ProjectileID.HoundiusShootiusFireball;
            }
            else if (player.HasBuff(BuffID.Plantero))
            {
                type = ProjectileID.ChlorophyteArrow;
            }
            else if (player.HasBuff(BuffID.PetDD2Gato))//Propeller Gato bufg
            {
                type = ProjectileID.MonkStaffT2Ghast;
            }
            else if (player.HasBuff(BuffID.Puppy))
            {
                type = ProjectileID.RayGunnerLaser;
            }
            else if (player.HasBuff(BuffID.PetSapling))
            {
                type = ProjectileID.ThornChakram;
            }
            else if (player.HasBuff(BuffID.PetSpider))
            {
                type = ProjectileID.SpiderEgg;
            }
            else if (player.HasBuff(BuffID.ShadowMimic))
            {
                type = ProjectileID.UnholyTridentFriendly;
            }
            else if (player.HasBuff(BuffID.SharkPup))
            {
                type = ProjectileID.MiniSharkron;
            }
            else if (player.HasBuff(BuffID.Squashling))
            {
                type = ProjectileID.FlamingJack;
            }
            else if (player.HasBuff(BuffID.SugarGlider))
            {
                type = ProjectileID.RottenEgg;
            }
            else if (player.HasBuff(BuffID.TikiSpirit))
            {
                type = ProjectileID.PoisonFang;
            }
            else if (player.HasBuff(BuffID.PetTurtle))
            {
                type = ProjectileID.ToxicBubble;
            }
            else if (player.HasBuff(BuffID.VoltBunny))
            {
                type = ProjectileID.Electrosphere;
            }
            else if (player.HasBuff(BuffID.ZephyrFish))
            {
                type = ProjectileID.FrostDaggerfish;
            }
            //Master Mode Pets
            else if (player.HasBuff(BuffID.MartianPet))
            {
                type = ProjectileID.ElectrosphereMissile;
            }
            else if (player.HasBuff(BuffID.DD2OgrePet))
            {
                type = ProjectileID.DD2PhoenixBowShot;
            }
            else if (player.HasBuff(BuffID.DestroyerPet))
            {
                type = ProjectileID.LightBeam;
            }
            else if (player.HasBuff(BuffID.EaterOfWorldsPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.EverscreamPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.QueenBeePet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.IceQueenPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.DD2BetsyPet))
            {
                type = ProjectileID.DD2PhoenixBowShot;
            }
            else if (player.HasBuff(BuffID.SkeletronPrimePet))
            {
                type = ProjectileID.LightBeam;
            }
            else if (player.HasBuff(BuffID.MoonLordPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.LunaticCultistPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.PlanteraPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.TwinsPet))
            {
                type = ProjectileID.LightBeam;
            }
            else if (player.HasBuff(BuffID.SkeletronPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.KingSlimePet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.QueenSlimePet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.BrainOfCthulhuPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.EyeOfCthulhuPet))
            {
                type = ProjectileID.BloodyMachete;
            }
            else if (player.HasBuff(BuffID.DeerclopsPet))
            {
                type = ProjectileID.InsanityShadowFriendly;
            }
            else if (player.HasBuff(BuffID.DukeFishronPet))
            {
                type = ProjectileID.BloodyMachete;
            }
*/