using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Items
{
    public class HuntingRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hunting Rifle");
            Tooltip.SetDefault("Turns musket balls into high velocity bullets\n\"For... Hunting...\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null)
            {
                Item.damage = 260;
            }
            else
            {
                Item.damage = 125;
            }

            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Yellow; //Post EoC Craft
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/HuntingRifleShoot")
            {
                Volume = 0.6f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 200
                ;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.ArmorPenetration = 50;
            Item.crit = 16;

        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null && calamityMod.TryFind("AshesofCalamity", out ModItem AshesofCalamity))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(AshesofCalamity.Type, 10);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddIngredient(ItemID.HallowedBar, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }//Adds calamity recipe
            else
            {
                Recipe recipe2 = CreateRecipe();
                recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe2.AddIngredient(ItemID.SoulofMight, 1);
                recipe2.AddIngredient(ItemID.SoulofFright, 1);
                recipe2.AddIngredient(ItemID.SoulofSight, 1);
                recipe2.AddIngredient(ItemID.HallowedBar, 10);
                recipe2.AddTile(TileID.MythrilAnvil);
                recipe2.Register();
            }//Adds recipe if calamity is not installed

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<ModifiedHuntingRifle>(), 1);
            recipe3.AddIngredient(ModContent.ItemType<NutsnBolts>(), 1);
            recipe3.AddTile(TileID.TinkerersWorkbench);
            recipe3.Register();

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


            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }


        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

    }
}