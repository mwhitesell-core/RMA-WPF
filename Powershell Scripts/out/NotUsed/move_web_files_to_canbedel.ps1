#-------------------------------------------------------------------------------
# File 'move_web_files_to_canbedel.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'move_web_files_to_canbedel'
#-------------------------------------------------------------------------------



echo "This program will move wyymmdd.* to canbedel sub-directories"
echo ""
echo ""
echo "**** Hit new line to continue ****"
 $garbage = Read-Host

Set-Location $env:application_root\production\web
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web1
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web2
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web3
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web4
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web5
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web6
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web7
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web8
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web9
Move-Item -Force w15* canbedel
Set-Location $env:application_root\production\web10
Move-Item -Force w15* canbedel
