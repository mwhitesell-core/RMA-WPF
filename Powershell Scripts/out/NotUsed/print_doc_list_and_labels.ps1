#-------------------------------------------------------------------------------
# File 'print_doc_list_and_labels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_doc_list_and_labels'
#-------------------------------------------------------------------------------

echo "PRINT_DOC_LIST_AND_LABELS"
echo ""
echo ""
echo "ENTER TYPE OF LIST TO PRINT"
echo ""
echo "                   1 - PAYROLL LIST  (CANCELLED)"
echo "                   2 - BILLING LIST"
echo "                   3 - DOCTOR  DUMP  (CANCELLED)"
echo "                   4 - ADDRESS LABELS"
echo "                   5 - DOCTOR  LABELS *SIGNATURE*"
echo "                   6 - DOCTOR  LIST   *PROMP USER FOR DATES*"
echo "                   7 - LIST OF DOCTORS WITH PAY CODE 2  3  AND  4"
echo "                   8 - DOCTOR LABELS FOR TAX PURPOSES  (CANCELLED)"
echo ""
echo "Enter Type ?"
&$string = Read-Host
echo ""
echo ""
if ("$string" -eq "1")
 {
    Get-Content payrolllist.txt | Out-Printer
} else {
    if ("$string" -eq "2")
 {
        Get-Content billinglist.txt | Out-Printer
    } else {
  if ("$string" -eq "3")
 {
            Get-Content doctordump.txt | Out-Printer
  } else {
     if ("$string" -eq "4")
 {
                Get-Content addrlabels.txt | Out-Printer
          } else {
             if ("$string" -eq "5")
 {
                    Get-Content signaturelabels.txt | Out-Printer
             } else {
             if ("$string" -eq "6")
 {
                        Get-Content doctorlist.txt | Out-Printer
              } else {
                     if ("$string" -eq "7")
 {
                            Get-Content docpaycode.txt | Out-Printer
                  } else {
                     if ("$string" -eq "8")
 {
                                Get-Content taxlabels.txt | Out-Printer
                           } else {
                              echo ""
                              echo "INVALID OPTION"
                            echo ""
                          }
                      }
                     }
                 }
             }
         }
     }
 }
echo ""
echo ""
echo "FINISHED...."
echo ""
