#-------------------------------------------------------------------------------
# File 'rat_copy_68.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_68'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 68 group 6064  ..."
$garbage = Read-Host
echo ""
#cd $pb_data
#mv P*6064* ohip_rat_ascii
Set-Location $env:application_production\68
&$env:COBOL u030a 6064 12 Y
Set-Location $pb_data
Move-Item -Force ohip_rat_ascii ohip_rat_ascii_68
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
