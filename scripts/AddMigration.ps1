$path = $MyInvocation.MyCommand.Path
$parentPath = $(Split-Path (Split-Path $path -Parent) -Parent)
$message = $(Read-Host -Prompt 'Input message')

dotnet ef migrations add $message --project $parentPath --startup-project $parentPath --output-dir $parentPath\Persistence\Migrations --context MainDbContext
