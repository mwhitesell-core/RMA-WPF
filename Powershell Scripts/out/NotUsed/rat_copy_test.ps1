#-------------------------------------------------------------------------------
# File 'rat_copy_test.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_test'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 22 group 2215  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item -Force P*2215* ohip_rat_ascii
Set-Location $env:application_production
#cobrun $obj/u030a 1>u030a.log 2>&1 << RAT_EXIT
# use above line if you don't want the amount displayed but put on log file
#log file does not keep the screen values
&$env:COBOL u030a 2215 03 Y
Set-Location $pb_data
Move-Item -Force ohip_rat_ascii ohip_rat_ascii_22
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
