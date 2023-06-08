using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using FortniteItems.Content.Items.Consumables;

namespace FortniteItems.Content.Tiles
{
    public class HopRockOreTile : ModTile
    {
        public override string Texture => $"{nameof(FortniteItems)}/Assets/Textures/HopRockOreTile";
        //TODO change texture to obsidian tileset with altered colors
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = 118;
            RegisterItemDrop(ModContent.ItemType<HopRock>());

            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting

            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Hop Rock Chunk");
            AddMapEntry(new Color(65, 54, 152), name);

            //mineResist = 4f;
            //minPick = 200;
        }
    }
}