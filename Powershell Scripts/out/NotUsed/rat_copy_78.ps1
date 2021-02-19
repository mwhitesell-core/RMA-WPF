#-------------------------------------------------------------------------------
# File 'rat_copy_78.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_78'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 78 group AA8U  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item -Force P*AA8U* ohip_rat_ascii
Set-Location $env:application_production\78
&$env:COBOL u030a AA8U 01 Y
Set-Location $pb_data
Move-Item -Force ohip_rat_ascii ohip_rat_ascii_78
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
