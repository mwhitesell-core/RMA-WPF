#-------------------------------------------------------------------------------
# File 'rebuild_ohiptape.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rebuild_ohiptape.com'
#-------------------------------------------------------------------------------

# this macro will rebuild an "editted" rat ascii file back into the original
# rat ascii format that was received from OHIP (ie. one with no cr/lf)
# this macro is used when the incoming rat has to be corrrected
# and is "dumped" so that it can be vi'd.

echo " "
echo " "
if (-not(Test-Path u020_tapeout_file.dump ))
{
  echo "`a`a`aERROR -can't find your editted 'u020_tapeout_file.dump'"
  echo "macro terminating !"
  echo " "
} else {
  if (Test-Path u020_tapeout_file)
  {
    echo "Warning - existing 'u020_tapeout_file' found - renamed to .bak"
    echo "        - make sure you delete it when the ohip tape is successfully created!"
    echo " "
    Move-Item -Force u020_tapeout_file u020_tapeout_file.bak
  }
  echo "New 'u020_tapeout_file' file being created from editted file ..."
Get-Content u020_tapeout_file.dump |  awk++ $env:cmd\rebuild_ohiptape.awk > u020_tapeout_file
  echo "done !"
}
