#-------------------------------------------------------------------------------
# File 'newu701_4.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701_4'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

               &$env:QTP u705
               echo ""
               echo "cleanup: rename input file as successfully processed"
               Move-Item -Force submit_disk_susp.in submit_disk_${1}.out
