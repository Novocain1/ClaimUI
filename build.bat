@echo off
REM Build script for ClaimUI mod
REM Builds in Release mode and creates a distributable zip package

echo Building ClaimUI mod...
dotnet build ClaimUI.csproj -c Release

if %ERRORLEVEL% neq 0 (
    echo Build failed!
    exit /b 1
)

echo.
echo Creating distribution package...

REM Create temporary staging directory
if exist "dist" rmdir /s /q "dist"
mkdir "dist\ClaimUI"

REM Copy files to staging
copy "bin\ClaimUI.dll" "dist\ClaimUI\" >nul
copy "bin\resources\modinfo.json" "dist\ClaimUI\" >nul
copy "bin\resources\modicon.png" "dist\ClaimUI\" >nul

REM Create zip file
if exist "ClaimUI.zip" del "ClaimUI.zip"
powershell -Command "Compress-Archive -Path 'dist\ClaimUI\*' -DestinationPath 'ClaimUI.zip'"

REM Cleanup
rmdir /s /q "dist"

echo.
echo Build complete!
echo Distribution package: ClaimUI.zip
echo.
echo Install by extracting to your Vintage Story mods folder:
echo   Windows: %%APPDATA%%\VintagestoryData\Mods\
echo   Linux: ~/.config/VintagestoryData/Mods/
