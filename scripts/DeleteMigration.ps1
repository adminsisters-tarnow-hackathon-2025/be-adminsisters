$path = $MyInvocation.MyCommand.Path
$parentPath = $(Split-Path (Split-Path $path -Parent) -Parent)
dotnet ef migrations remove --project $parentPath --startup-project $parentPath --context MainDbContext