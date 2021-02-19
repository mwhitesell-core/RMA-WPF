#-------------------------------------------------------------------------------
# File 'run_meditech_upload.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_meditech_upload'
#-------------------------------------------------------------------------------

#run_meditech_upload
# 2002/may/16 B.E. - original

echo "running automated job ..."

echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo "$SHELL"

echo "Setting up Profile ..."
. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill101c\upload\run_meditech_upload.log
echo "Setting up Environment ..."
rmabill 101c >> $Env:root\alpha\rmabill\rmabill101c\upload\run_meditech_upload.log
Get-Location

echo ""

Set-Location $env:application_root
Set-Location production
Get-Location
echo "testing process flag ..."
if (Test-Path run_u011_in_batch.flg)
{
  echo "Running$env:cmd\upload_meditech_patients med_down"
    &$env:cmd\upload_meditech_patients med_down
  echo ""
  echo "automated job DONE!"
} else {
  echo "Processing Flag NOT found - bypass the running of procedure"
}
