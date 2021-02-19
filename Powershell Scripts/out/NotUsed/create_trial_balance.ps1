#-------------------------------------------------------------------------------
# File 'create_trial_balance.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_trial_balance'
#-------------------------------------------------------------------------------

echo "CREATE_TRIAL_BALANCE"
echo ""
echo ""
echo "CREATE THE TRIAL BALANCE REPORT"
echo ""
echo "HIT   `"NEWLINE`"   TO CONTINUE ..."
 $garbage = Read-Host
echo ""
echo "PROGRAMR070A NOW LOADING ..."

&$env:COBOL r070a
&$env:COBOL r070b
&$env:COBOL r070c

echo ""
echo ""
echo ""
echo "-------- TO PRINT THE  `"TRIAL BALANCE REPORT`""
echo ""
echo "-------- RUN PROGRAM PRINT_TRIAL_BALANCE"
echo ""
echo "TO FINISH THIS RUN  HIT   `"NEWLINE`"  ..."
 $garbage = Read-Host
echo ""
echo ""
