# ClaimUI Mod for Vintage Story

A standalone GUI interface for managing land claims in Vintage Story. This mod provides a radial button interface for quick access to claim commands.

## Features

- **Hotkey Access**: Press `L` to toggle the Claim UI (configurable via game settings)
- **Radial Button Layout**: Quick access to all claim commands via GUI
- **Persistent State**: GUI automatically reopens on game restart if it was open previously
- **OP Mode**: Toggle mode for modifying claim grid values

## Claim Commands

The UI provides buttons for the following commands:

- **New**: Create a new claim (`/land claim new`)
- **Start**: Begin claim selection (`/land claim start`)
- **End**: Finalize claim selection (`/land claim end`)
- **Add**: Add area to existing claim (`/land claim add`)
- **Cancel**: Cancel current operation (`/land claim cancel`)
- **Save**: Save claim data (`/land claim save [name]`)
- **U**: Grow/shrink claim up (`/land claim grow up 1` or `/land claim shrink up 1`)
- **D**: Grow/shrink claim down (`/land claim grow down 1` or `/land claim shrink down 1`)
- **N**: Grow/shrink claim north (`/land claim grow north 1` or `/land claim shrink north 1`)
- **S**: Grow/shrink claim south (`/land claim grow south 1` or `/land claim shrink south 1`)
- **E**: Grow/shrink claim east (`/land claim grow east 1` or `/land claim shrink east 1`)
- **W**: Grow/shrink claim west (`/land claim grow west 1` or `/land claim shrink west 1`)
- **OP**: Toggle between grow and shrink modes

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
