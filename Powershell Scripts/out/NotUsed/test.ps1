#-------------------------------------------------------------------------------
# File 'test.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test'
#-------------------------------------------------------------------------------

echo "running test"


echo "HIT   `"NEWLINE`"  1st time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  2nd time  TO CONTINUE ..."
 $garbage = Read-Host

echo "HIT   `"NEWLINE`"  3rd time  TO CONTINUE ..."
 $garbage = Read-Host

Set-Location $env:application_production
