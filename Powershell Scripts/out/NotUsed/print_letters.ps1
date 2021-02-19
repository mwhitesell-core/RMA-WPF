#-------------------------------------------------------------------------------
# File 'print_letters.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_letters'
#-------------------------------------------------------------------------------

# print_letters
clear
echo ""
echo "** DO F\ASS ON R085.TXT  IF THERE IS A FILE R085.TXT  **"
echo ""
echo "**********   LOAD RMA LETTERHEAD ONTO PRINTER   **********"
echo ""
echo "THEN HIT   `"NEWLINE`"   TO PRINT PATIENT LETTERS (R085.TXT)"
 $garbage = Read-Host

echo ""
echo ""

Get-Content r085.txt | Out-Printer
