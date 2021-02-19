#-------------------------------------------------------------------------------
# File 'hold_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hold_claims'
#-------------------------------------------------------------------------------

# CHANGE HOLD_CLAIMS_MESS.CLI ALSO

Remove-Item r030g.txt *> $null
Remove-Item r030g1.sf* *> $null

&$env:QUIZ r030g 20000101 20160118

#lp r030g.txt 1>/dev/null 2>&1 
