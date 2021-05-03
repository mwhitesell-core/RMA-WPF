#-------------------------------------------------------------------------------
# File 'verify_solo_payroll_ok_to_run.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'verify_solo_payroll_ok_to_run'
#-------------------------------------------------------------------------------

# 2014/Oct/14   MC1     no longer need to pass parameter for u100.qts but need in u100_b.qzs
# 2014/Oct/15   MC2     include the run of u100_c.qzs

echo "Running verify_solo_payroll_ok_to_run ..."
echo ""
Get-Date
echo ""


Set-Location $env:application_root\production
Remove-Item  u100_b.txt, u100_c.txt, u100_d.txt, u100_e.txt, u100_f.txt, u100_b_src.txt -EA SilentlyContinue
Remove-Item  u100* -include .sf*

# MC1 - reinstate below
$rcmd = $env:QTP + "u100"
invoke-expression $rcmd

#qtp << QTP_EXIT
#exec $obj/u100.qtc
#C
#QTP_EXIT

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
$rcmd = $env:QUIZ + "u100_b"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "u100_c"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "u100_d"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "u100_e"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "u100_f"
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

#New-Item U100.txt -type file -force

#Get-Content u100_b.txt >> U100.txt -EA SilentlyContinue
#Get-Content u100_c.txt >> U100.txt -EA SilentlyContinue
#Get-Content u100_d.txt >> U100.txt -EA SilentlyContinue
#Get-Content u100_e.txt >> U100.txt -EA SilentlyContinue
#Get-Content u100_f.txt >> U100.txt -EA SilentlyContinue

#Get-Content u100.txt -EA SilentlyContinue

#Remove-Item  u100_b.txt, u100_c.txt, u100_d.txt, u100_e.txt, u100_f.txt -EA SilentlyContinue

# 2014/Sep/24 - MC1
$rcmd = $env:QUIZ + "u100_b_src_PASS1 C"
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
Get-Content u100_b.txt -EA SilentlyContinue


echo ""
echo "The following report U100_c.txt should be blank - otherwise DONT run payoll!"
echo ""

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content u100.txt | Out-Printer -Name $env:networkprinter -EA SilentlyContinue
   Get-Content u100_b.txt | Out-Printer -Name $env:networkprinter -EA SilentlyContinue
}
