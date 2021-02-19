#-------------------------------------------------------------------------------
# File 'update_f050_f051_f060_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_f050_f051_f060_bk1'
#-------------------------------------------------------------------------------

# 
#    SUBMIT A BATCH JOB AT NIGHT TO UPDATE DOCTOR REVENUE, DOCTOR
#    CASH, CHEQUE REGISTER FILE FOR CLINIC NBR OR DEPT NO CHANGE.

&$env:QTP u901 ${1} ${2} ${1} ${2} >> u901.log
