using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Consumables;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Rarities;

namespace FortniteItems.Content.Items.Weapons
{
    public class ExoticHeistedRunNGunSMG : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/ExoticHeistedRunNGunSMG";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Exotic Heisted Run 'N' Gun Submachine Gun");
            // Tooltip.SetDefault("70% chance to not use ammo\nTurns musket balls into high velocity bullets\nGrants the holder the \"Slapped Up\" buff\n\"Hotwire's weapon of choice\"");
            //since no NPC sells this item or is associated with this item, I just chose to put a favorite skin of mine as the weapon holder.

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //EoW SMG
        public override void SetDefaults()
        {

            Item.damage = 230;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0.1f;
            Item.value = Item.sellPrice(gold: 30);
            Item.rare = ModContent.RarityType<Exotic>(); //Exotic
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

            if (calamityMod != null && calamityMod.TryFind("AuricBar", out ModItem Auric) && calamityMod.TryFind("CosmicAnvil", out ModTile CosmicAnvil))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.ItemType<CompactSMG>(), 1);
                recipe.AddIngredient(ModContent.ItemType<ExoticEssence>(), 1);
                recipe.AddIngredient(ModContent.ItemType<SlapJuice>(), 5);
                recipe.AddIngredient(Auric.Type, 5);
                recipe.AddTile(CosmicAnvil.Type);
                recipe.Register();
            }//Adds recipe if calamity mod is installed
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.LunarBar, 12);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
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

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.7f;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.SlappedUp>(), 60);
        }
    }
}
