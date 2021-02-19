#-------------------------------------------------------------------------------
# File 'mary_adj.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mary_adj'
#-------------------------------------------------------------------------------

# 2010/09/24  yas Print total Adj for the month                                    

Remove-Item r950*.txt *> $null
Remove-Item r950*.sf* *> $null

&$env:QUIZ r950a
&$env:QUIZ r950b
&$env:QUIZ r950c
Move-Item -Force r950c.txt r950c_dtl.txt

&$env:QUIZ r950c rep

Move-Item -Force r950c.txt r950c_tot.txt

Get-Content r950c_tot.txt | Out-Printer
