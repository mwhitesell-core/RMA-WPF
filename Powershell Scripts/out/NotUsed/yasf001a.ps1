#-------------------------------------------------------------------------------
# File 'yasf001a.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasf001a'
#-------------------------------------------------------------------------------

echo ""
echo "STAGE  #3A  - RUN VERIFY OF CLAIMS FOR A REPORT OF FILE AFTER DELETION ."

&$env:COBOL r071
Remove-Item r071_after *> $null
Move-Item -Force r071 r071_after

echo ""
Get-ChildItem -Force r071_after
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

Get-Content r071_after | Out-Printer

echo ""
Get-Date
echo ""
echo "STAGE    #3B    - RUN `"ALL_BATCHES`" FOR REPORT OF FILE AFTER REPORT ..."

&$env:COBOL r001b

Remove-Item r001b_after_r093 *> $null
Move-Item -Force r001b r001b_after_r093

echo ""
Get-ChildItem -Force r001b_after_r093
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

#lp      r001b_after_r093


echo ""
echo "FINISHED ..."
