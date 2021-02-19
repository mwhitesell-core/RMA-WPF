#-------------------------------------------------------------------------------
# File 'check_f001_f002_all.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'check_f001_f002_all'
#-------------------------------------------------------------------------------

# $cmd/check_f001_f002_all    - this macro will access f001 & f002 hdr/dtl to determine if
#                               differences found between the files

# program "check_f001_f002_all.qzs" is in $src directory
#It only picks up records with batch status < 2 (not yet update to f050 file).
#It will display records in extf002hdr_diff.txt if there is difference between f001 & f002 hdr (amount or nbr of claims),
#and in extf002dtl_diff.txt if there is difference between f001 & f002 dtl (amount or nbr of svc)

# 2012/Nov/28 - add the timestamp for reports & log

echo ""
echo "Setting up Profile ..."
. $root\macros\profile  >> $root\alpha\rmabill\rmabill101c\production\check_f001_f002_all.log

echo ""
echo "Setting up Environment ..."
rmabill 101c  >> $root\alpha\rmabill\rmabill101c\production\check_f001_f002_all.log

echo "Entering `'producton`' directory"
Set-Location $application_production; Get-Location
echo ""

Remove-Item extf002dtl_diff.txt
Remove-Item extf002hdr_diff.txt

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H:%M`")"

quiz++ $obj\check_f001_f002_all  > check_f001_f002_all_$timeStamp.log

Get-ChildItem *diff.txt

Move-Item extf002dtl_diff.txt extf002dtl_diff_$timeStamp.txt
Move-Item extf002hdr_diff.txt extf002hdr_diff_$timeStamp.txt
Move-Item extf002hdrdtl_diff.txt extf002hdrdtl_diff_$timeStamp.txt

