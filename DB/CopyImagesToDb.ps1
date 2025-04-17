# Chnage the Folders
$zielOrdner = "C:\ProgramData\MySQL\MySQL Server 8.0\Uploads\Image\"
$quelleOrdner = "C:\IMS-T4_23\Praktikum\CharacterConfigurator\CharacterConfigurator\Resources\Image\"

if (-Not (Test-Path -Path $zielOrdner)) {
    New-Item -Path $zielOrdner -ItemType Directory
}

Copy-Item -Path "$quelleOrdner*" -Destination $zielOrdner -Recurse -Force