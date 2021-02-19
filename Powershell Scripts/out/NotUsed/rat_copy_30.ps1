#-------------------------------------------------------------------------------
# File 'rat_copy_30.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_30'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 30 group H290  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item -Force P*H290* ohip_rat_ascii
Set-Location $env:application_production\30
&$env:COBOL u030a H290 01 Y
Set-Location $pb_data
Move-Item -Force ohip_rat_ascii ohip_rat_ascii_30
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
