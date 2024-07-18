using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using FortniteItems.Content;
using System.Security.Cryptography.X509Certificates;

namespace FortniteItems
{
	public class FortniteItems : Mod
	{
        public static ModKeybind testKey;

        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
		{
			RecipeGroup MagicMirror = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MagicMirror)}", ItemID.IceMirror, ItemID.MagicMirror);
			RecipeGroup.RegisterGroup(nameof(ItemID.MagicMirror), MagicMirror);

            RecipeGroup Tier1Metals = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CobaltBar)}", ItemID.CobaltBar, ItemID.PalladiumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CobaltBar), Tier1Metals);

            RecipeGroup Tier2Metals = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MythrilBar)}", ItemID.MythrilBar, ItemID.OrichalcumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.MythrilBar), Tier2Metals);

            RecipeGroup Tier3Metals = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteBar)}", ItemID.AdamantiteBar, ItemID.TitaniumBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.AdamantiteBar), Tier3Metals);

            RecipeGroup BossSouls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SoulofMight)}", ItemID.SoulofMight, ItemID.SoulofFright, ItemID.SoulofSight);
            RecipeGroup.RegisterGroup(nameof(ItemID.SoulofMight), BossSouls);

            RecipeGroup IronAndLead = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronBar)}", ItemID.IronBar, ItemID.LeadBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.IronBar), IronAndLead);

			RecipeGroup DemonandCrim = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.DemoniteBar, ItemID.CrimtaneBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.DemoniteBar), DemonandCrim);

			RecipeGroup EvilMaterial = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.ShadowScale, ItemID.TissueSample);
			RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScale), EvilMaterial);

			RecipeGroup GoldandPlat = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), GoldandPlat);

            RecipeGroup FourthBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBow)}", ItemID.GoldBow, ItemID.PlatinumBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBow), FourthBow);

            
        }

    }
}