#-------------------------------------------------------------------------------
# File 'print_doctor_labels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_doctor_labels'
#-------------------------------------------------------------------------------

echo "PRINT_DOC_LABELS"
echo ""

echo "PRINT   DOCTOR MAILING  OR  SIGNATURE  LABELS"
echo ""
echo "!! WARNING !!"
echo "THIS PROGRAM USESSETFORMS AND MUST BE RUN FROM THE BACKGROUND CONSOLE"
echo ""
echo "DO YOU WISH TO ABORT NOW???"
echo ""
echo "HIT `"^C^A`" OR `"NEWLINE`"  TO CONTINUE ..."
 $garbage = Read-Host

echo ""
echo "WHAT DO YOU WANT TO PRINT?"
echo "MAILING  ORSIGNATURE  LABELS?"
echo ""
echo "HIT `"M`" OR `"S`"  TO CONTINUE ..."
&$string = Read-Host

echo ""
echo ""
echo "LOAD DOCTOR LABELS ON THE LINEPRINTER"
echo ""
echo "HIT  `"NEWLINE`"  WHEN READY..."
$garbage = Read-Host

if ("$string" -eq "M")
 {
Get-ChildItem -Force r020d
  echo ""
  echo ""
  Get-Content r020d | Out-Printer
}
if ("$string" -eq "S")
Get-ChildItem -Force r020e
  echo ""
  echo ""
  Get-Content r020e | Out-Printer
}

echo ""
echo ""
echo ""
echo "WHEN FINISHED PRINTING REMOVE LABELS FROM LINEPRINTER AND REPLACE WITH STANDARD PAPER"
echo ""
echo ""
echo ""

echo "HIT  `"NEWLINE`"  WHEN READY..."
$garbage = Read-Host


echo ""
echo "FINISHED ..."
