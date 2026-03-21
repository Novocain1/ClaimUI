# ClaimUI Mod for Vintage Story

A standalone GUI interface for managing land claims in Vintage Story. This mod provides a radial button interface for quick access to claim commands.

## Features

- **Hotkey Access**: Press `L` to toggle the Claim UI (configurable via game settings)
- **Radial Button Layout**: Quick access to all claim commands via GUI
- **Persistent State**: GUI automatically reopens on game restart if it was open previously
- **OP Mode**: Toggle mode for modifying claim grid values

## Claim Commands

The UI provides buttons for the following commands:

- **New**: Create a new claim
- **Start**: Begin claim selection
- **End**: Finalize claim selection
- **Add**: Add area to existing claim
- **Cancel**: Cancel current operation
- **Save**: Save claim data
- **U/D**: Adjust grid up/down
- **N/S**: Adjust grid north/south
- **E/W**: Adjust grid east/west
- **OP**: Toggle operation mode (multiply adjustments by -1)

## Building

### Prerequisites

- .NET 10 SDK
- Vintage Story 1.22.X installed at `C:\Games\Vintagestory\1.22.X`

### Build Instructions

```bash
dotnet build ClaimUI.csproj
```

The compiled mod will be output to the `bin\` directory.

### Installation

1. Build the mod using the instructions above
2. Copy the contents of `bin\` to your Vintage Story mods folder:
   - Windows: `%APPDATA%\VintagestoryData\Mods\`
   - Linux: `~/.config/VintagestoryData/Mods/`
3. Restart Vintage Story

## Credits

Original implementation by Novocain as part of the VSHUD mod. This standalone version extracts just the Claim UI functionality.

## License

Unlicense
