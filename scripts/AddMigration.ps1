$path = $MyInvocation.MyCommand.Path
$parentPath = $(Split-Path (Split-Path $path -Parent) -Parent)
$message = $(Read-Host -Prompt 'Input message')

dotnet ef migrations add $message --project $parentPath\src\AdminSisters.Api --startup-project $parentPath\src\AdminSisters.Api --output-dir $parentPath\src\AdminSisters.Api\Persistence\Migrations --context MainDbContext
