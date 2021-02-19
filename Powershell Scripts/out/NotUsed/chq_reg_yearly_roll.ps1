#-------------------------------------------------------------------------------
# File 'chq_reg_yearly_roll.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'chq_reg_yearly_roll'
#-------------------------------------------------------------------------------

echo "chq_reg_yearly_roll"
echo ""
echo ""
echo "Annual Physician Payroll Roll-over and Audit"
echo ""
echo "== WARNING =="
echo "This program must be executed only once a year !!!!! --"
echo "at the end of your fiscal year!!!!"
echo ""
echo "Do you wish to abort now???"
echo ""
echo "hitnewline   to continue ..."
$garbage = Read-Host
echo ""
echo "Program u190 now loading ..."
echo ""
echo ""
echo ""

&$env:COBOL u190
echo ""
Get-ChildItem -Force ru190
echo ""

echo "Hitnewline   to print rollover report"
 $garbage = Read-Host
echo ""

Get-Content ru190 | Out-Printer

echo ""
echo ""
echo ""
echo "hitnewline   to commence audit program ..."
 $garbage = Read-Host
echo ""
echo "program r191 now loading ..."
echo ""
echo ""
echo ""

&$env:COBOL r191

echo ""
# CONVERSION ERROR (unexpected, #45): Unknown command.
# $obj/length r191 
echo ""

echo "hitnewline   to print audit report"
 $garbage = Read-Host
echo ""

Get-Content r191 | Out-Printer

echo ""
echo "finished ...."
