using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Weapons
{
    public class CompactSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/CompactSMG";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Compact Submachine Gun");
            // Tooltip.SetDefault("70% chance to not use ammo\nTurns musket balls into high velocity bullets\n\"The gun with many names\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //EoW SMG
        public override void SetDefaults()
        {

            Item.damage = 121;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 3;
            Item.useAnimation = 3;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 26);
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
            if (calamityMod != null && calamityMod.TryFind("PureGreen", out ModRarity PureGreen))
            {
                Item.rare = PureGreen.Type; //Post Polter
            }
            else
            {
                Item.rare = -11; //Amber Rarity as this weapon is unobtainable without calamity
            }
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/CompactSMGShoot")
            {
                Volume = 0.7f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 5;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("DepthCells", out ModItem Cells) && calamityMod.TryFind("ReaperTooth", out ModItem Tooth))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<MakeshiftSMG>(), 1);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddIngredient(Cells.Type, 15);
                recipe.AddIngredient(Tooth.Type, 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }//Adds recipe if calamity mod is installed
            else
            {
                //NOTHING! this item is calamity exclusive!
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11f, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.7f;
        }

    }
}
