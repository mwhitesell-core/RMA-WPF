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


#Set-Location $application_root\production
Set-Location $env:application_production
Remove-Item u100.txt, u100_b_src.txt, u100_c_src.txt
Remove-Item u100*.sf*

# MC1 - reinstate below

$rcmd = $env:QTP + "u100"
invoke-expression $rcmd

#qtp << QTP_EXIT
#exec $obj/u100.qtc
#A
#QTP_EXIT

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
#quiz++ $obj\u100_B
$rcmd = $env:QUIZ + "u100_B"
invoke-expression $rcmd

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
#quiz++ $obj\u100_C
$rcmd = $env:QUIZ + "u100_C"
invoke-expression $rcmd

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
#quiz++ $obj\u100_D
$rcmd = $env:QUIZ + "u100_D"
invoke-expression $rcmd

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
#quiz++ $obj\u100_E
$rcmd = $env:QUIZ + "u100_E"
invoke-expression $rcmd

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
#quiz++ $obj\u100_F
$rcmd = $env:QUIZ + "u100_F"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content u100_B.txt > u100.txt
Get-Content u100_C.txt >> u100.txt
Get-Content u100_D.txt >> u100.txt
Get-Content u100_E.txt >> u100.txt
Get-Content u100_F.txt >> u100.txt

echo ""
echo "The following report U100.txt should be blank - otherwise DONT run payoll!"
echo ""
#Get-Content u100_b.txt 
#Get-Content u100_c.txt 
#Get-Content u100_d.txt 
#Get-Content u100_e.txt 
#Get-Content u100_f.txt 
Get-Content u100.txt 

# 2014/Sep/24 - MC1

$rcmd = $env:QUIZ + "u100_b_src_PASS1 A"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "u100_b_src_PASS2"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "u100_b_src_PASS3"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "u100_b_src_PASS4"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "u100_b_src_PASS5"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "u100_b_src_PASS6"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content u100_b_src_PASS6.txt > u100_b.txt

$rcmd = $env:QUIZ + "u100_c_src"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content u100_c_src.txt > u100_c.txt

echo ""
echo "The following report U100_b.txt should be blank - otherwise DONT run payoll!"
echo ""
Get-Content u100_b.txt 

# MC2
echo ""
echo "The following report U100_C.txt should be blank - otherwise DONT run payoll!"
echo ""
Get-Content u100_c.txt 


#Get-Content u100_b.txt | Out-Printer
#Get-Content u100_c.txt | Out-Printer
#Get-Content u100_d.txt | Out-Printer
#Get-Content u100_e.txt | Out-Printer
#Get-Content u100_f.txt| Out-Printer
Get-Content u100.txt| Out-Printer
Get-Content u100_b.txt| Out-Printer
Get-Content u100_c.txt| Out-Printer
