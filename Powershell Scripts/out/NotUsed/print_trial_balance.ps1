#-------------------------------------------------------------------------------
# File 'print_trial_balance.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_trial_balance'
#-------------------------------------------------------------------------------

echo "PRINT_TRIAL_BALANCE"

echo ""

echo "PRINT THE TRIAL BALANCE REPORT"
echo ""
echo "HIT  `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host

echo ""
echo "ENTER THE CLINIC NBR OF THE REPORT TO BE PRINTED -"
echo ""

&$var1 = Read-Host

Get-ChildItem r070_${var1}

echo ""
echo ""

echo "HIT  `"NEWLINE`"  TO PRINT THE REPORT ..."
$garbage = Read-Host

Get-Content r070_${var1} | Out-Printer

echo ""
echo ""
echo "FINISHED ...."

echo ""
echo ""
