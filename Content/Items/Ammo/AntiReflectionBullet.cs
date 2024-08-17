using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace FortniteItems.Content.Items.Ammo
{
    public class AntiReflectionBullet : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MissingTexture";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Copper Bullet");
            // Tooltip.SetDefault("a crude bullet made out of a soft metal"); // The item's description, can be set to whatever you want.

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 1; //Damage is weak as it is added to the musket ball projectile. the reason the musket ball projectile is used is so it is overlapped by bullet modifications
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(copper: 1);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.AntiReflectionBullet>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4; // The speed of the projectile.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.

            
        }
    }
}
