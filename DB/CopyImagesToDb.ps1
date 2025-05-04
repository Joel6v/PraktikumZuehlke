# Chanage the Folders
$destinationFolder = "C:\ProgramData\MySQL\MySQL Server 8.4\Uploads\Image\"
$sourceFolder = "\ProjektZuehlke\CharacterConfigurator\CharacterConfigurator\Resources\Image"

Copy-Item -Path "$sourceFolder*" -Destination $destinationFolder -Recurse -Force