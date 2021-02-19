#-------------------------------------------------------------------------------
# File 'f020_info_export.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'f020_info_export.com'
#-------------------------------------------------------------------------------

# f020_info_export.com

echo "CREATE export file in MP environment ..."
echo ""

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location
&$env:QTP f020_info_export
Copy-Item f020_info_export.sf* $Env:root\alpha\rmabill\rmabill101c\upload


Copy-Item F020C_DOC_CLINIC_EXPORT.sf* $Env:root\alpha\rmabill\rmabill101c\upload

echo ""
echo "Setup of 101c environment"
echo ". $Env:root\macros\setup_rmabill.com  101c"
# CONVERSION ERROR (unexpected, #14): Unknown command.
# whence rmabill
# CONVERSION ERROR (unexpected, #15): Unknown command.
# ./rmabill 101c

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "UPLOAD data into 101c environment"
echo "dict =  $DICT"
echo "obj =  $obj"
echo "obj =  $obj"
echo "data =  $data"
echo "Running Upload program"
&$env:QTP f020_info_import

echo "Done!"
