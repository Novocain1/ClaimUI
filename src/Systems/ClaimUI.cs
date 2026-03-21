using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace ClaimUI
{
    class ClaimUISystem : ClientModSystem
    {
        public override void StartClientSide(ICoreClientAPI api)
        {
            GuiDialogClaimUI gui = new GuiDialogClaimUI(api);

            api.Input.RegisterHotKey("claimgui", "Open Claim GUI", GlKeys.L, HotkeyType.GUIOrOtherControls);

            api.Event.LevelFinalize += () =>
            {
                if (api.Settings.Bool["claimGui"])
                {
                    gui.TryOpen();
                }
            };

            api.Input.SetHotKeyHandler("claimgui", a =>
            {
                gui.Toggle();
                return true;
            });
        }
    }
}
