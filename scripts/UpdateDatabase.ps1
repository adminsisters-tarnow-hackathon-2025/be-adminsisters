$path = $MyInvocation.MyCommand.Path
$parentPath = $(Split-Path (Split-Path $path -Parent) -Parent)

dotnet ef database update --project $parentPath\src\AdminSisters.Api --startup-project $parentPath\src\AdminSisters.Api --context MainDbContext
