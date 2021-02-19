#-------------------------------------------------------------------------------
# File 'create_letters.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_letters'
#-------------------------------------------------------------------------------

Remove-Item r085.txt *> $null
Remove-Item r086.txt *> $null
Remove-Item r087.txt *> $null

&$env:QUIZ r085
&$env:QUIZ r086
&$env:QUIZ r087
&$env:QTP u085

Get-Content r086.txt | Out-Printer *> $null
Get-Content r087.txt | Out-Printer *> $null

echo ""
echo ""

echo "**********   load rma letterhead onto printer   **********"
echo ""
echo "Then hitnewline   to print patient letters"
 $garbage = Read-Host

echo ""
echo ""

Get-Content r085.txt | Out-Printer
