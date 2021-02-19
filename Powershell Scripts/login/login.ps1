$env:srvname = "CORE-10-173"
New-PSSession -ComputerName $env:srvname -Credential mwhitesell@coremig.local
set-alias vi “C:\Program Files (x86)\Notepad++\notepad++.exe”
##Set-Alias go  E:\RMAPOWERSHELL\rma.appref-ms
Set-Alias rmabill  "D:\Projects\RMA WPF\Powershell Scripts\out\rmabill"
##function global:prompt { "PS=$(Split-Path -NoQualifier(Get-Location))`n$ " }
$ErrorView = "CategoryView"
