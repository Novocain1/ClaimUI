# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ClaimUI is a client-side Vintage Story mod that provides a GUI interface for land claim management. It was ported from the VSHUD mod as a standalone feature. The mod sends chat commands to the game's native `/land claim` system through a radial button interface.

## Build System

This is a .NET 10.0 C# project targeting Vintage Story 1.22.X.

**Build command:**
```bash
dotnet build ClaimUI.csproj
```

**Output location:** `bin\` directory contains:
- `ClaimUI.dll` - The compiled mod assembly
- `modinfo.json` - Mod metadata (copied from `resources\`)

**Important:** The project requires .NET 10 SDK because Vintage Story 1.22.X is built against System.Runtime 10.0.0.0.

## Project Configuration

**Vintage Story path dependency:** The `.csproj` file references VintagestoryAPI.dll and VintagestoryLib.dll from `C:\Games\Vintagestory\1.22.X`. If the user has VS installed elsewhere, update the `VintageStoryPath` property in `ClaimUI.csproj`.

**Key .csproj settings:**
- `SpecificVersion=False` on VS references to prevent version mismatch errors
- `EnableDefaultCompileItems=false` with explicit `src\**\*.cs` compilation
- `ImplicitUsings=disable` - all using directives must be explicit
- `Nullable=disable` - nullable reference types are disabled

## Architecture

### Component Structure

**ClaimUISystem** ([src/Systems/ClaimUI.cs](src/Systems/ClaimUI.cs))
- Extends `ClientModSystem` (requires `using Vintagestory.API.Common`)
- Entry point for the mod
- Registers hotkey "claimgui" (default: L key)
- Creates single `GuiDialogClaimUI` instance
- Restores GUI state on level finalization using `api.Settings.Bool["claimGui"]`

**GuiDialogClaimUI** ([src/Dialog/GuiDialogClaimUI.cs](src/Dialog/GuiDialogClaimUI.cs))
- Extends `GuiDialog` (requires `using Vintagestory.API.Client`)
- Implements the radial button UI
- Positioned at `EnumDialogArea.LeftMiddle`
- 12 toggle buttons for claim commands + 1 OP toggle button
- Buttons auto-reset after 50ms via `RegisterCallback`

### UI Layout Pattern

The dialog uses a radial layout created through `ElementBounds.CopyOffsetedSibling()`:
- `radialRoot` is the center anchor point at (165, 15) offset from dialog origin
- 12 command buttons positioned in offsets from this root (-150 to +25 pixels)
- 13th button (OP toggle) placed at the root position
- Dialog bounds: 200x100 pixels

### Command Dispatch

All buttons send chat messages via `capi.SendChatMessage("/land claim ...")`:
- Cases 0-5: Direct commands (new, start, end, add, cancel, save)
- Cases 6-11: Grid adjustments with multiplier `m` (affected by OP mode)
- OP mode: When `op == true`, multiplier `m = -1`, otherwise `m = 1`

### State Persistence

The mod persists GUI visibility state:
- `TryOpen()` sets `api.Settings.Bool["claimGui"] = true`
- `TryClose()` sets `api.Settings.Bool["claimGui"] = false`
- On level finalization, GUI reopens if setting is `true`

## Namespace

All code uses `namespace ClaimUI`. The main system class is named `ClaimUISystem` (not `ClaimUI`) to avoid namespace collision.

## Required Using Directives

- `ClaimUISystem` requires: `Vintagestory.API.Client` and `Vintagestory.API.Common`
- `GuiDialogClaimUI` requires: `Vintagestory.API.Client`
