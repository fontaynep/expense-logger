# Set working directory to where the script is
Set-Location -Path $PSScriptRoot

Write-Host "Publishing project..." -ForegroundColor Cyan
dotnet publish -c Release -o publish

if ($LASTEXITCODE -ne 0) {
    Write-Error "Publish failed. Fix errors before deploying."
    exit
}

Write-Host "Zipping published output..." -ForegroundColor Cyan
Compress-Archive -Path publish\* -DestinationPath publish.zip -Force

Write-Host "Deploying to Azure..." -ForegroundColor Cyan
az webapp deployment source config-zip `
    --resource-group ExpenseNinja_group `
    --name expenseninja `
    --src publish.zip

if ($LASTEXITCODE -eq 0) {
    Write-Host "Deployed successfully!" -ForegroundColor Green
    Start-Process "https://expenseninja.azurewebsites.net"
} else {
    Write-Error "Deployment failed."
}
