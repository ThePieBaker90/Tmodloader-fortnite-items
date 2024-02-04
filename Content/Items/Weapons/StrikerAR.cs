using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Weapons
{
    public class StrikerAR : ModItem
    {
        //Scope Mods Range From 0-4
        //0 == Iron Sights
        //1 == Red Eye Sight 
        //2 == Holo-13 Optic
        //3 == P2X Optic
        //4 == Sniper Optic
        public int scope;

        //Magazine Mods Range From 0-2
        //0 == Default Mag
        //1 == Speed Mag
        //2 == Drum Mag
        public int magazine;

        //Underbarrel Mods Range From 0-3
        //0 == No Underbarrel
        //1 == Vertical Foregrip
        //2 == Angled Foregrip
        //3 == Laser
        public int underbarrel;

        //Barrel Mods Range From 0-2
        //0 == Default Barrel
        //1 == Suppressor
        //2 == Muzzle Brake
        public int barrel;
        

        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/StrikerAR";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tactical Assault Rifle");
            // Tooltip.SetDefault("45% chance to not consume ammo\n\"Standard issue I.O. guard rifle\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a fast rifle 
        public override void SetDefaults()
        {
            Item.damage = 46;
            Item.DamageType = ModContent.GetInstance<AssaultRifleClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 8, silver: 50);
            Item.rare = ItemRarityID.Lime; //frost moon
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/TacticalARShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.crit = 21;
            Item.ArmorPenetration = 10;
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

        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.45f;

        }
        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}