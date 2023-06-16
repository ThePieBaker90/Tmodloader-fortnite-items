using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FortniteItems.Content.Items.Weapons
{
    public class DualPistols : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/DualPistols";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dual Barrel Pistol");
            //Even though the dual barrel pistol is not a thing in fortnite, there is no way that i've found to make the player appear to be holding two items at once
            //So this is my workaround, it will work the exact same way as the dual pistols, just a different name and look
            // Tooltip.SetDefault("33% chance to not use ammo\n\"It's a shame you can't just hold two pistols at once\"");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //a post plague burst pistol
        public override void SetDefaults()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
            if (calamityMod != null
                && calamityMod.TryFind("InfectedArmorPlating", out ModItem InfectedPlate)
                && calamityMod.TryFind("DubiousPlating", out ModItem DubiousPlate)
                && calamityMod.TryFind("PlagueCellCanister", out ModItem PlagueCanister))
            {
                Item.damage = 223;
                Item.value = Item.sellPrice(gold: 12);
            }
            else
            {
                Item.damage = 57;
                Item.value = Item.sellPrice(gold: 5);
            }

            Item.knockBack = 1f;
            Item.useTime = 6;
            Item.useAnimation = 12 ;
            Item.reuseDelay = 12;
            Item.shootSpeed = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.Yellow; //Post plaguebringer goliath
            Item.UseSound = new SoundStyle($"{nameof(FortniteItems)}/Assets/Sounds/Items/Guns/DualPistolsShoot")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;

        }

        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);

            if (calamityMod != null
                && calamityMod.TryFind("InfectedArmorPlating", out ModItem InfectedPlate)
                && calamityMod.TryFind("DubiousPlating", out ModItem DubiousPlate)
                && calamityMod.TryFind("PlagueCellCanister", out ModItem PlagueCanister))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(InfectedPlate.Type, 7);
                recipe.AddIngredient(DubiousPlate.Type, 12);
                recipe.AddIngredient(PlagueCanister.Type, 20);
                recipe.AddIngredient(ModContent.ItemType<MakeshiftPistol>(), 2);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

            }//adds calamity recipe
            else
            {

            }

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


        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.33f;
        }

    }
}
