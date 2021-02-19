#-------------------------------------------------------------------------------
# File 'run_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ar'
#-------------------------------------------------------------------------------

echo "THIS WILL CREATE AND PRINT  R070 FOR CLINICS 80$Env:root\81\60"
echo "** HIT NEW LINE  TO  CONTINUE  **"
 $garbage = Read-Host
echo ""

&$env:COBOL r070a 80 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

Get-Content r070_80 | Out-Printer

&$env:COBOL r070a 81 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

Get-Content r070_81 | Out-Printer

&$env:QUIZ r070atp
&$env:QUIZ r070btp
&$env:QUIZ r070ctp
&$env:QUIZ r070dtp
Get-Content r070dtp.txt | Add-Content r070ctp.txt
Move-Item -Force r070ctp.txt r070tp_60
Get-Content r070tp_60 | Out-Printer
