#-------------------------------------------------------------------------------
# File 'r070tp_61to65.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r070tp_61to65'
#-------------------------------------------------------------------------------

&$env:QUIZ r070atp
&$env:QUIZ r070btp
&$env:QUIZ r070ctp
&$env:QUIZ r070dtp

Get-Content r070dtp.txt | Add-Content r070ctp.txt
Move-Item -Force r070ctp.txt r070tp_60
