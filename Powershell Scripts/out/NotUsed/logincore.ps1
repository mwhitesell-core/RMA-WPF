$env:srvname = "rmasql2016"
New-PSSession -ComputerName $env:srvname -Credential username@coremig.local
set-alias vi “C:\Program Files (x86)\Notepad++\notepad++.exe”
Set-Alias go  c:\rma\rma.appref-ms
Set-Alias rmabill  \\$env:srvname\RMA\Scripts\rmabill
$env:7z = 'C:\Program Files\7-Zip\7z.exe'
function global:prompt { "PS=$(Split-Path -NoQualifier(Get-Location))`n$ " }