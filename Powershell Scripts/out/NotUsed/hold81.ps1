#-------------------------------------------------------------------------------
# File 'hold81.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hold81'
#-------------------------------------------------------------------------------

# CHANGE HOLD_CLAIMS_MESS.CLI ALSO

Remove-Item hold81.txt *> $null
Remove-Item r030g5.sf* *> $null

&$env:QUIZ hold81 20000101 20160118

#lp hold81.txt   1>/dev/null 2>&1
