#-------------------------------------------------------------------------------
# File 'update_f050_f051_f060.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_f050_f051_f060.bk1'
#-------------------------------------------------------------------------------

# update_f050_f051_f060
#    update doctor revenue, doctor cash, cheque register files
#    to change the doctor's department. If a 3rd parameter (date) is
#    passed then only records on/after that date are changed.
#
#  this job tests to see if the 'indicator' file exists before it runs - if
#  and then removes it after running

# setup directory for testing

# CONVERSION ERROR (unexpected, #11): Not 2 or 3 keywords in simple assignment.
# directory='/alpha/rmabill/rmabillxxx'; export directory

# CONVERSION ERROR (unexpected, #13): Not 2 or 3 keywords in simple assignment.
# application_production=$directory'/production'; export application_production
# CONVERSION ERROR (unexpected, #14): Not 2 or 3 keywords in simple assignment.
# cmd=$directory'/cmd'; export cmd
# CONVERSION ERROR (unexpected, #15): Not 2 or 3 keywords in simple assignment.
# pb_data=$directory'/data'; export pb_data
# CONVERSION ERROR (unexpected, #16): Not 2 or 3 keywords in simple assignment.
# obj=$directory'/obj'; export obj

echo "testing ifindicator file found"
Set-Location $pb_data

if (Test-Path batch_update_f050_f051_f060.flg)
{
   echo "indicator file found"

   Set-Location $env:application_production
Get-Content $pb_data\batch_update_f050_f051_f060.flg |   $env:QTP u901 >> u901.log

   Set-Location $pb_data
#  (remove the 3 parameter lines from .flg file and rebuild new parm file if
#   more transactions found)
Get-Content batch_update_f050_f051_f060.flg |   awk++ $env:cmd\batch_update_f050.awk
   mv batch_update_f050_f051_f060.flg batch_update_f050_f051_f060.run.$(Get-Date -uformat "%Y_%m_%d_time_%H:%M")
#  (if more transactions then rename to correct parm file and recall this macro)
   echo "testing if more parms"
   if (Test-Path batch_update_f050_f051_f060.flg.new)
   {
      echo "parms found"
      Move-Item -Force batch_update_f050_f051_f060.flg.new batch_update_f050_f051_f060.flg
      echo "recalling this macro"
            &$env:cmd\update_f050_f051_f060
   } else {
        echo "NO more parms"
   }
} else {
  echo "indicator file not found"
}
