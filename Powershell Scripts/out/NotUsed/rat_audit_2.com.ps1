#-------------------------------------------------------------------------------
# File 'rat_audit_2.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_audit_2.com'
#-------------------------------------------------------------------------------

echo "Running rat_audit_2.com ..."
echo ""
echo "WARNING - you must have vi'd rat.ps to eliminate unwanted clinic data"
echo "         or you will be auditing multi-clinic rat records!!!!"
echo ""
echo "Hit Enter to continue ..."
$garbage = Read-Host
echo ""

Set-Location $env:application_production

echo "starting rat_audit_1 ..."
&$env:QUIZ rat_audit_1

echo "starting rat_audit_2 ..."
&$env:QUIZ rat_audit_2

echo "starting rat_audit_3 ..."
&$env:QUIZ rat_audit_3

echo "starting rat_audit_4 ..."
&$env:QUIZ rat_audit_4

echo "starting rat_audit_5 ..."
&$env:QUIZ rat_audit_5

echo "starting rat_audit_6a ..."
&$env:QUIZ rat_audit_6a

echo "starting rat_audit_6b ..."
&$env:QUIZ rat_audit_6b

echo "starting rat_audit_6c ..."
&$env:QUIZ rat_audit_6c

echo "starting rat_audit_8 ..."
&$env:QUIZ rat_audit_8

echo "starting rat_audit_10 ..."
&$env:QUIZ rat_audit_10

Get-Content rat_audit_1.txt, rat_audit_2.txt, rat_audit_3.txt, rat_audit_4.txt, rat_audit_5.txt, rat_audit_6a.txt, `
  rat_audit_6b.txt, rat_audit_6c.txt, rat_audit_8.txt, rat_audit_10.txt | Set-Content rat_audit.txt
#lp rat_audit.txt

echo ""
echo "Done!"
