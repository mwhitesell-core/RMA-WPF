#-------------------------------------------------------------------------------
# File 'update_f050_f051_f060.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'update_f050_f051_f060'
#-------------------------------------------------------------------------------

# update_f050_f051_f060
#    update doctor revenue, doctor cash, cheque register files
#    to change the doctor's department. If a 3rd parameter (date) is
#    passed then only records on/after that date are changed.
#
#  this job tests to see if the 'indicator' file exists before it runs - if
#  and then removes it after running


$macros = "$root\\macros"
$audit_file = "$root\\audit\\applications.audit"
$RELNOTES = "$root\\relnotes"

# CONVERSION WARNING; Korn shell setup.
# ENV=$macros/sys.kshrc; export ENV

. $macros\globals
. $macros\toolkit

# POWERHOUSE setup
# CONVERSION WARNING; Cognos setup.
# COGNOS=/usr/cognos                              ; export COGNOS

# CONVERSION WARNING; umask is involved.
# umask 002

# LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE
. $macros\setup_rmabill.com 101c
# LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE LIVE

Set-Location $pb_data

if (Test-Path batch_update_f050_f051_f060.flg)
{
   echo " "
   echo "Department Change 'indicator' file FOUND $(udate)"

   Set-Location $application_production
#   qtp auto=$obj/u901.qtc < $pb_data/batch_update_f050_f051_f060.flg \
#                        >> /beta/rmabill/rmabill101c/production/u901.log
#   qtp auto=$obj/u901.qtc < $pb_data/batch_update_f050_f051_f060.flg \
#                        >> /dyad/rmabill101c/production/u901.log
Get-Content $pb_data\batch_update_f050_f051_f060.flg |    qtp++ $obj\u901  >> $root\dyad\rmabill\rmabill101c\production\u901.log
   echo "Processing completed$(udate)"

   Set-Location $pb_data
#  (remove the 3 parameter lines from .flg file and rebuild new parm file if
#   more transactions found)
Get-Content batch_update_f050_f051_f060.flg |    awk++ $cmd\batch_update_f050.awk
# CONVERSION ERROR
#    mv batch_update_f050_f051_f060.flg batch_update_f050_f051_f060.run.`date +%Y_%m_%d_time_%H:%M`
# Can't convert; Not all identifiers/numbers.
#  (if more transactions then rename to correct parm file and recall this macro)
   echo "testing if more parms"
   if (Test-Path batch_update_f050_f051_f060.flg.new)
   {
      echo "parms found"
      Move-Item batch_update_f050_f051_f060.flg.new batch_update_f050_f051_f060.flg
      echo "recalling this macro"
            $cmd\update_f050_f051_f060
   } else {
        echo "NO more parms$(udate)"
   }
} else {
   echo "Department Change 'indicator' file NOT found $(udate)"
}
