#-------------------------------------------------------------------------------
# File 'verify_101c_payroll_ok_to_run.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'verify_101c_payroll_ok_to_run'
#-------------------------------------------------------------------------------

# 2014/Oct/14   MC1     no longer need to pass parameter for u100.qts but need in u100_b.qzs
# 2014/Oct/15   MC2     include the run of u100_c.qzs   

echo "Running verify_101c_payroll_ok_to_run ..."
echo ""
Get-Date
echo ""


Set-Location $application_root\production
Remove-Item u100.txt, u100_b.txt, u100_c.txt
Remove-Item u100*.sf*

# MC1 - reinstate below
qtp++ $obj\u100

#qtp << QTP_EXIT
#exec $obj/u100.qtc
#A
#QTP_EXIT

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
quiz++ $obj\u100
echo ""
echo "The following report U100.txt should be blank - otherwise DONT run payoll!"
echo ""
Get-Contents u100.txt | Out-Host -paging

# 2014/Sep/24 - MC1
$pipedInput = @"
use  $src/u100_b.qzs
A 
;20140630
use $src/u100_c.qzs
exit
"@

$pipedInput | quiz++


echo ""
echo "The following report U100_b.txt should be blank - otherwise DONT run payoll!"
echo ""
Get-Contents u100_b.txt | Out-Host -paging

# MC2
echo ""
echo "The following report U100_C.txt should be blank - otherwise DONT run payoll!"
echo ""
Get-Contents u100_c.txt | Out-Host -paging

Get-Contents u100.txt| Out-Printer
Get-Contents u100_b.txt| Out-Printer
Get-Contents u100_c.txt| Out-Printer
