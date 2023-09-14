using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.Items.Materials;
using FortniteItems.Content.Items.Weapons;
using System;
using Terraria.DataStructures;
using FortniteItems.Content.DamageClasses;

namespace FortniteItems.Content.Items.Accessories
{
    public class PistolSalvo : ModItem
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/MissingTexture";

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Lime; //shroomite craft
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 5);
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<PistolClass>()) *= 1.45f;
            player.GetAttackSpeed(ModContent.GetInstance<PistolClass>()) *= 0.90f;
        }



    }
}
