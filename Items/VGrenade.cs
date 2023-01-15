using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Items
{
    public class VGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {

            ModLoader.TryGetMod("SOTS", out Mod SOTS);

            if (SOTS == null)
            {
                DisplayName.SetDefault("Vindertech Grenade");
                Tooltip.SetDefault("Explodes after a set amount of time instead of upon impact\n\"Throw 'em and hope\"");
            }
            else
            {
                DisplayName.SetDefault("THIS IS INCOMPATABLE WITH SOTS");
                Tooltip.SetDefault("THIS ITEM DOES NOT FUNCTION PROPERLY IN SECRETS OF THE SHADOWS\nDO NOT USE THIS ITEM IF YOU SEE THIS\nyou are not missing out on much, it is simply a grenade that does greater damage but that does not explode upon entity impact");
            }


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        //Post eye consumable gotten from the demo man
        public override void SetDefaults()
        {

            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.sellPrice(copper: 50);
            Item.value = Item.buyPrice(silver: 5);
            ModLoader.TryGetMod("SOTS", out Mod SOTS);

            if (SOTS == null)
            {
                Item.rare = ItemRarityID.Blue; //Post Eye Sold by Demo
            }
            else
            {
                Item.rare = ItemRarityID.Red; //to show the item is incompatable
            }
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.VGrenade>();
            Item.shootSpeed = 10;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.ArmorPenetration = 25;
            Item.consumable = true;
            Item.maxStack = 999;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9f, 0);
        }


    }
}
