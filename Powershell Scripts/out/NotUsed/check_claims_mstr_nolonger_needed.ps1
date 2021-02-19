#-------------------------------------------------------------------------------
# File 'check_claims_mstr_nolonger_needed.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_claims_mstr_nolonger_needed'
#-------------------------------------------------------------------------------

echo ""
Get-Date > check_claims_mstr.log
echo ""
# 2000/mar/02 B.E. - changed to run in batch, also $obj macro was missing

#batch 1>check_claims_mstr.ls 2>&1 << BATCH_EXIT
#setdict rma

&$env:QUIZ check_claims_mstr >> check_claims_mstr.log 2> check_claims_mstr.log
#lp r905.txt
#lp r906.txt
#lp r907.txt
echo ""
Get-Date >> check_claims_mstr.log
echo ""
#BATCH_EXIT
