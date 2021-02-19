#-------------------------------------------------------------------------------
# File 'rebuild_rat.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rebuild_rat.com'
#-------------------------------------------------------------------------------

# this macro will rebuild an "editted" rat ascii file back into the original
# rat ascii format that was received from OHIP (ie. one with no cr/lf)
# this macro is used when the incoming rat has to be corrrected
# and is "dumped" so that it can be vi'd.

echo " "
echo " "
if (-not(Test-Path ohip_rat_ascii.dump ))
{
  echo "`a`a`aERROR -can't find your editted 'rat_ascii_file.dump"
  echo "macro terminating !"
  echo " "
} else {
  if (Test-Path ohip_rat_ascii)
  {
    echo "Warning - existing 'rat_ascii_file' found - renamed to .bak"
    echo "        - make sure you delete it when the rat is successfully applied!"
    echo " "
    Move-Item -Force ohip_rat_ascii ohip_rat_ascii.bak
  }
  echo "New rat_ascii_file being created from editted file ..."
Get-Content ohip_rat_ascii.dump |  awk++ $env:cmd\rebuild_rat.awk > ohip_rat_ascii
  echo "done !"
}
