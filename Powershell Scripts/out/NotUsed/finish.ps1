#-------------------------------------------------------------------------------
# File 'finish.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'finish'
#-------------------------------------------------------------------------------

echo ""
echo "Transferring Suspend header\detail\desc records into Claims Master"
&$env:QTP newu706a

#cobrun $obj/u706b

echo ""
echo "Printing report of errors in Suspended Detail file"
&$env:QUIZ r709a


echo ""
echo "Printing report of errors in Suspended Header file"
&$env:QUIZ r709b

Get-Content r709b.txt | Out-Printer *> $null
Get-Content r709a.txt | Out-Printer *> $null
