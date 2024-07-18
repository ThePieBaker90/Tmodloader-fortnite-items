using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using FortniteItems.Content.DamageClasses;
using FortniteItems.Content.Items.Materials;
using Terraria.UI;
using System.Collections.Generic;

namespace FortniteItems.Content.UI
{
    public class ReloadUISystem : ModSystem 
    {
        internal UserInterface ReloadInterface;
        internal class BaseUI : UIState { }
        internal BaseUI ReloadUI;
        private GameTime _lastUpdateUIGameTime;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                ReloadInterface = new UserInterface();
                ReloadUI = new BaseUI();
                ReloadUI.Activate();
            }
        }

        public override void Unload()
        {
            ReloadUI?.Deactivate();
            ReloadUI=null;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUIGameTime = gameTime;
            if (ReloadInterface?.CurrentState != null)
            {
                ReloadInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (_lastUpdateUIGameTime != null && ReloadInterface?.CurrentState != null)
                        {
                            ReloadInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        internal void ShowMyUI()
        {
            ReloadInterface?.SetState(ReloadUI);
        }

        internal void HideMyUI()
        {
            ReloadInterface?.SetState(null);
        }
    }
   
}
