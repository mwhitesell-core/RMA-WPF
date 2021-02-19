#-------------------------------------------------------------------------------
# File 'verify_doctor_premiums.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_doctor_premiums.bk1'
#-------------------------------------------------------------------------------

# macro: verify_doctor_premiums   
# 2013/Sep/11 M.C. consolidate r031a_AGE3/AGEP/MOHR/MOHD  into r031a.dat, determine if any UNDEFINED doctors 

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-Content r031a_AGE3.dat, r031a_AGEP.dat, r031a_MOHR.dat, r031a_MOHD?.dat | Set-Content r031a.dat

echo ""
echo "execute powerhouse program r031_before_update_3.qzc"
echo ""
&$env:QUIZ r031_before_update_3

Remove-Item r031b_undefined_doc.txt
Move-Item -Force r031b.txt r031b_undefined_doc.txt
#lp r031b_undefined_doc.txt   
echo "Do NOT continue if the below report is NOT EMPTY"
Get-Content r031b_undefined_doc.txt

echo ""
echo ""
Get-Date
