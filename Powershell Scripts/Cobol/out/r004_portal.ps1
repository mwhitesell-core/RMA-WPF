#-------------------------------------------------------------------------------
# File 'r004_portal.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r004_portal'
#-------------------------------------------------------------------------------

Remove-Item r004*portal*, r004*sf*

$pipedInput = @"
exec $obj/r004a
$1 
exec $obj/r004b
exec $obj/r004c
exec $obj/r004d
exec $obj/r004c_portal
exec $obj/r004c_portal_ss
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004c_portal.txt r004c_portal_${2}.txt

# be 2013/apr/22
#mv r004c_portal_ss.txt r004c_portal_ss_${2}.csv
##awk -f $cmd/remove_rpt_heading.awk r004c_portal_ss.txt r004c_portal_ss_${2}.csv

Move-Item r004c_portal_ss.txt r004c_portal_ss_${2}.csv
