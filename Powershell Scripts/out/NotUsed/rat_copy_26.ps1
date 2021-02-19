#-------------------------------------------------------------------------------
# File 'rat_copy_26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_26'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 26 group 1837 ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item -Force P*1837* ohip_rat_ascii
Set-Location $env:application_production\26
&$env:COBOL u030a 1837 04 Y
Set-Location $pb_data
Move-Item -Force ohip_rat_ascii ohip_rat_ascii_26

Set-Location $env:application_production\26

echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
