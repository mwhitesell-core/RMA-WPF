#-------------------------------------------------------------------------------
# File 'check_f001_f002_all.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
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
#. $Env:root\macros\profile  >> $Env:root\alpha\rmabill\rmabill101c\production\check_f001_f002_all.log

echo ""
echo "Setting up Environment ..."
rmabill $env:RMABILL_VERS >> \\$Env:root\alpha\rmabill\rmabill101c\production\check_f001_f002_all.log

echo "Entering `'producton`' directory"
Set-Location $env:application_production ; Get-Location
echo ""

Remove-Item extf002dtl_diff.txt
Remove-Item extf002hdr_diff.txt

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H_%M`")"

$rcmd = $env:QUIZ + "check_f001_f002_all_1" 
Invoke-Expression $rcmd > check_f001_f002_all_$timeStamp.log
$rcmd = $env:QUIZ + "check_f001_f002_all_2" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log

#Core - Added to rename report according to quiz file
Get-Content check_f001_f002_all_2.txt > extf002hdr_diff.txt

$rcmd = $env:QUIZ + "check_f001_f002_all_3" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log
$rcmd = $env:QUIZ + "check_f001_f002_all_4" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log

#Core - Added to rename report according to quiz file
Get-Content check_f001_f002_all_4.txt > extf002dtl_diff.txt

$rcmd = $env:QUIZ + "check_f001_f002_all_5" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log
$rcmd = $env:QUIZ + "check_f001_f002_all_6" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log

#Core - Added to rename report according to quiz file
Get-Content check_f001_f002_all_6.txt > extf002hdrdtl_diff.txt

$rcmd = $env:QUIZ + "check_f001_f002_all_7" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log
$rcmd = $env:QUIZ + "check_f001_f002_all_8" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log

#Core - Added to rename report according to quiz file
Get-Content check_f001_f002_all_8.txt > orphaned_batches.txt

$rcmd = $env:QUIZ + "check_f001_f002_all_9" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log
$rcmd = $env:QUIZ + "check_f001_f002_all_10" 
Invoke-Expression $rcmd >> check_f001_f002_all_$timeStamp.log

#Core - Added to rename report according to quiz file
Get-Content check_f001_f002_all_10.txt > orphaned_claims.txt

Get-ChildItem *diff.txt

Move-Item -Force extf002dtl_diff.txt extf002dtl_diff_$timeStamp.txt
Move-Item -Force extf002hdr_diff.txt extf002hdr_diff_$timeStamp.txt
Move-Item -Force extf002hdrdtl_diff.txt extf002hdrdtl_diff_$timeStamp.txt
Move-Item -Force orphaned_batches.txt orphaned_batches_$timeStamp.txt
Move-Item -Force orphaned_claims.txt orphaned_claims_$timeStamp.txt

