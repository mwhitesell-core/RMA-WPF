#-------------------------------------------------------------------------------
# File 'rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat'
#-------------------------------------------------------------------------------

echo ""
# CONVERSION ERROR (unexpected, #2): Not 2 or 3 keywords in simple assignment.
# PATH=${PATH}:$pb_data:$production:$batch:$macros
# CONVERSION ERROR (unexpected, #3): Not 2 or 3 keywords in simple assignment.
# PATH=${PATH}:/macros:/util/production/prod_procedurelib
# CONVERSION ERROR (unexpected, #4): Not 2 or 3 keywords in simple assignment.
# PATH=${PATH}:/cognos/powerhouse/525d
# CONVERSION ERROR (unexpected, #5): Unknown command.
# export PATH
Set-Location $application_upl
echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER 81 FOR CLINIC  ****"
echo "Hit     `"NEWLINE`"      to continue ..."
$garbage = Read-Host
&$env:COBOL u030a
echo "Hit     `"NEWLINE`"      to continue ..."
$garbage = Read-Host
