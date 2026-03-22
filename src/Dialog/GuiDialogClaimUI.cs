using Vintagestory.API.Client;

namespace ClaimUI
{
    class GuiDialogClaimUI : GuiDialog
    {
        public bool op = false;
        public GuiDialogClaimUI(ICoreClientAPI capi) : base(capi)
        {
            this.capi = capi;
        }

        public override void OnOwnPlayerDataReceived()
        {
            base.OnOwnPlayerDataReceived();

            ElementBounds radialRoot = ElementBounds.Fixed(EnumDialogArea.LeftMiddle, 0, 0, 25, 25);
            ElementBounds dialogBounds = radialRoot.CopyOffsetedSibling(0, 0, 200, 100);
            ElementBounds bgBounds = dialogBounds.CopyOffsetedSibling();
            radialRoot = radialRoot.WithFixedOffset(165, 15);

            SingleComposer = capi.Gui.CreateCompo("claim", dialogBounds)
                .AddDialogTitleBar("ClaimUI", () => TryClose(), CairoFont.WhiteSmallText())
                .AddDialogBG(bgBounds)
                .AddTextToggleButtons(new string[] { "New", "Start", "End", "Add", "Cancel", "Save", "U", "D", "N", "S", "E", "W", "List", "Load" }, CairoFont.ButtonText().WithFontSize(10),
                i =>
                {
                    int m = op ? -1 : 1;
                    switch (i)
                    {
                        case 0:
                            capi.SendChatMessage("/land claim new");
                            break;
                        case 1:
                            capi.SendChatMessage("/land claim start");
                            break;
                        case 2:
                            capi.SendChatMessage("/land claim end");
                            break;
                        case 3:
                            capi.SendChatMessage("/land claim add");
                            break;
                        case 4:
                            capi.SendChatMessage("/land claim cancel");
                            break;
                        case 5:
                            capi.SendChatMessage("/land claim save " + capi.World.Claims.All.Count);
                            break;
                        case 6:
                            capi.SendChatMessage(op ? "/land claim shrink up 1" : "/land claim grow up 1");
                            break;
                        case 7:
                            capi.SendChatMessage(op ? "/land claim shrink down 1" : "/land claim grow down 1");
                            break;
                        case 8:
                            capi.SendChatMessage(op ? "/land claim shrink north 1" : "/land claim grow north 1");
                            break;
                        case 9:
                            capi.SendChatMessage(op ? "/land claim shrink south 1" : "/land claim grow south 1");
                            break;
                        case 10:
                            capi.SendChatMessage(op ? "/land claim shrink east 1" : "/land claim grow east 1");
                            break;
                        case 11:
                            capi.SendChatMessage(op ? "/land claim shrink west 1" : "/land claim grow west 1");
                            break;
                        case 12:
                            capi.SendChatMessage("/land list");
                            break;
                        case 13:
                            capi.SendChatMessage("/land claim load " + capi.World.Claims.All.Count);
                            break;
                        default:
                            break;
                    }
                    capi.Event.RegisterCallback(dt => SingleComposer.GetToggleButton("buttons-" + i).On = false, 50);
                },
                new ElementBounds[]
                {
                    radialRoot.CopyOffsetedSibling(-150, -25, 25),  // [0] New
                    radialRoot.CopyOffsetedSibling(-150, 0, 25),    // [1] Start
                    radialRoot.CopyOffsetedSibling(-150, 25, 25),   // [2] End
                    radialRoot.CopyOffsetedSibling(-100, 0, 25),    // [3] Add
                    radialRoot.CopyOffsetedSibling(-100, -25, 25),  // [4] Cancel
                    radialRoot.CopyOffsetedSibling(-100, 25, 25),   // [5] Save
                    radialRoot.CopyOffsetedSibling(25, -25),        // [6] U (Up)
                    radialRoot.CopyOffsetedSibling(25, 25),         // [7] D (Down)
                    radialRoot.CopyOffsetedSibling(0, -25),         // [8] N (North)
                    radialRoot.CopyOffsetedSibling(0, 25),          // [9] S (South)
                    radialRoot.CopyOffsetedSibling(25, 0),          // [10] E (East)
                    radialRoot.CopyOffsetedSibling(-25, 0),         // [11] W (West)
                    radialRoot.CopyOffsetedSibling(-50, -25, 25),         // [12] List
                    radialRoot.CopyOffsetedSibling(-50, 25, 25),          // [13] Load
                    radialRoot,                                     // [14] OP toggle (at center)
                }, "buttons")
                .AddToggleButton("OP", CairoFont.ButtonText().WithFontSize(10),
                b =>
                {
                    op = b;
                }, radialRoot)
                .Compose();
        }

        public override bool TryOpen()
        {
            if (base.TryOpen())
            {
                OnOwnPlayerDataReceived();
                capi.Settings.Bool["claimGui"] = true;
                return true;
            }
            return false;
        }

        public override bool TryClose()
        {
            if (base.TryClose())
            {
                capi.Settings.Bool["claimGui"] = false;
                op = false;
                Dispose();
                return true;
            }
            return false;
        }

        public override string ToggleKeyCombinationCode => "claimgui";
    }
}
