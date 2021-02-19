#-------------------------------------------------------------------------------
# File 'print_doc_lists.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_doc_lists'
#-------------------------------------------------------------------------------

echo "PRINT_DOC_LISTS"
echo ""
echo ""
echo "ENTER TYPE OF LIST TO PRINT"
echo ""
echo "1 - PAYROLL LIST"
echo "2 - BILLING LIST"
echo "3 - DOCTOR  DUMP"
echo ""
echo "Enter Type ?"
&$string = Read-Host
echo ""
echo ""
if ("$string" -eq "1")
 {
Get-ChildItem -Force r020a
    echo ""
    Get-Content r020a | Out-Printer
} else {
    if ("$string" -eq "2")
 {
Get-ChildItem -Force r020b
      echo ""
   Get-Content r020b | Out-Printer
    } else {
 if ("$string" -eq "3")
 {
Get-ChildItem -Force r020c
      echo ""
           Get-Content r020c | Out-Printer
        } else {
     echo ""
      echo "INVALID OPTION"
            echo ""
  }
    }
}

echo ""
echo ""
echo "FINISHED...."
echo ""
