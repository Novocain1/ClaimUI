#!/bin/bash
# Build script for ClaimUI mod
# Builds in Release mode and creates a distributable zip package

echo "Building ClaimUI mod..."
dotnet build ClaimUI.csproj -c Release

if [ $? -ne 0 ]; then
    echo "Build failed!"
    exit 1
fi

echo ""
echo "Creating distribution package..."

# Create temporary staging directory
rm -rf dist
mkdir -p dist/ClaimUI

# Copy files to staging
cp bin/ClaimUI.dll dist/ClaimUI/
cp bin/resources/modinfo.json dist/ClaimUI/
cp bin/resources/modicon.png dist/ClaimUI/

# Create zip file
rm -f ClaimUI.zip
cd dist
zip -r ../ClaimUI.zip ClaimUI/
cd ..

# Cleanup
rm -rf dist

echo ""
echo "Build complete!"
echo "Distribution package: ClaimUI.zip"
echo ""
echo "Install by extracting to your Vintage Story mods folder:"
echo "  Windows: %APPDATA%\VintagestoryData\Mods/"
echo "  Linux: ~/.config/VintagestoryData/Mods/"
