#-------------------------------------------------------------------------------
# File 'create_doc_list_and_labels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_doc_list_and_labels'
#-------------------------------------------------------------------------------

clear
echo "                     Doctor Labels and Lists"
echo "                     -----------------------"
echo " "
echo "             Please select one of the following options"
echo ""
echo "               1.  Payroll List   (cancelled)"
echo "               2.  Billing List"
echo "               3.  Ballot Labels (creates 300)"
echo "               4.  Address Labels"
echo "               5.  Signature Labels"
echo "               6.  Doctor Listing **prompt user for start dates and term dates**"
echo "               7.  List of Doctors with Pay Code 2  3  and  4"
echo "                   Key Claim for these doctors first"
echo "               8.  Proxy Labels (creates 300)"
echo "               9.  T4a Labels"
echo ""
echo ""
echo ""
echo ""
echo "Enter Option:"
$var4 = Read-Host
echo ""
if ($var4 -eq 1) { &$env:cmd\payroll }
if ($var4 -eq 2) { &$env:cmd\billing }
if ($var4 -eq 3) { 
                   $rcmd = $env:QUIZ +"ballot DISC_ballot.rf";Invoke-Expression $rcmd
                   
                   #CORE - RDL fix
                   cat ballot.txt -raw | %{$_.replace("`f", "`r`n")} > ballot2.txt
                   copy-item ballot2.txt ballot.txt
                   remove-item ballot2.txt
                 }
if ($var4 -eq 4) {
                   &$env:cmd\addrlabels

                   #CORE - RDL fix
                   cat addresslabels.txt -raw | %{$_.replace("`f", "`r`n")} > addresslabels2.txt
                   copy-item addresslabels2.txt addresslabels.txt
                   remove-item addresslabels2.txt
                 }
if ($var4 -eq 5) { &$env:cmd\signaturelabels }
if ($var4 -eq 6) { &$env:cmd\doctorlist }
if ($var4 -eq 7) { &$env:cmd\docpaycode }
if ($var4 -eq 8) { $rcmd = $env:QUIZ +"proxy";Invoke-Expression $rcmd  }
if ($var4 -eq 9) { &$env:cmd\t4a_addrlabels }
if ($var4 -lt 1 -or $var4 -gt 9) { echo "Invalid Option`a" }
