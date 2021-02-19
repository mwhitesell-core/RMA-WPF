#-------------------------------------------------------------------------------
# File 'verify_doctor_premiums.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'verify_doctor_premiums'
#-------------------------------------------------------------------------------

# macro: verify_doctor_premiums   
# 2013/Sep/11 M.C. consolidate r031a_AGE3/AGEP/MOHR/MOHD  into r031a.dat, determine if any UNDEFINED doctors 
# 2014/May/08 NC1  delete r031b*.txt before execution
Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

#MC1
Remove-Item r031b.txt
Remove-Item r031b_undefined_doc.txt

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat, r031a_MOHD?.dat > r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_3.qzc"
echo ""
$rcmd = $env:QUIZ+"r031_before_update_3"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r031_before_update_3.txt > r031b.txt

Move-Item -Force r031b.txt r031b_undefined_doc.txt
#lp r031b_undefined_doc.txt   
echo "Do NOT continue if the below report is NOT EMPTY"
Get-Content r031b_undefined_doc.txt

echo ""
echo ""
Get-Date
