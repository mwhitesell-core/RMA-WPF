#-------------------------------------------------------------------------------
# File 'utl0025.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0025'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4,
  [string] $5,
  [string] $6
)

echo " "  >> $pb_prod\utl0025.log
echo " "  >> $pb_prod\utl0025.log
echo " "  >> $pb_prod\utl0025.log
echo "START OF RECOVERY"  >> $pb_prod\utl0025.log
echo "  for user ....:  $HOME"  >> $pb_prod\utl0025.log
echo " "  >> $pb_prod\utl0025.log
Get-Date  >> $pb_prod\utl0025.log
echo "Fixing batch ..: [$1] after a 'red ball' ... "  >> $pb_prod\utl0025.log
echo "Location was...: [$2] "  >> $pb_prod\utl0025.log
echo "Agent was .....: [$3] "  >> $pb_prod\utl0025.log
echo "In\Out was ....: [$4] "  >> $pb_prod\utl0025.log
echo "Payroll was ...: [$5] "  >> $pb_prod\utl0025.log
echo "F001 exists was: [$6] "  >> $pb_prod\utl0025.log
## qtp auto=$obj/fixf001.qtc  
echo " "  >> $pb_prod\utl0025.log

$pipedInput = @"
exec $obj/utl0025.qtc 
$1
$2
$3
$4 
$5
$6
"@

$pipedInput | qtp++  >> $pb_prod\utl0025.log

echo "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ "  >> $pb_prod\utl0025.log
echo "The recovery processs has finished."  >> $pb_prod\utl0025.log
echo "REVIEW THE ABOVE STATISTICS to ENSURE NO ERRORS were reported!"  >> $pb_prod\utl0025.log
echo " "  >> $pb_prod\utl0025.log
echo "Press ENTER to return to normal batch entry program"  >> $pb_prod\utl0025.log
echo "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ "  >> $pb_prod\utl0025.log
