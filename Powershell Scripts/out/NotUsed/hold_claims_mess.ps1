#-------------------------------------------------------------------------------
# File 'hold_claims_mess.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hold_claims_mess'
#-------------------------------------------------------------------------------

# CHANGE HOLD_CLAIMS.CLI ALSO

Remove-Item hold_mess.txt
Remove-Item r030g3.sf*

&$env:QUIZ r030g3 20000101 20160118

Get-Content hold_mess.txt | Out-Printer
