#-------------------------------------------------------------------------------
# File 'docpaycode.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'docpaycode'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo "LIST OF DOCTORS WITH PAY CODE  2   3  AND 4"
echo ""
echo "KEY CLAIMS FOR THESE DOCTORS FIRST"
echo ""
echo "HITNEW LINE TO CONTINUE OR CTRL ^C TO EXIT"
$garbage = Read-Host
echo ""
echo ""
echo "PLEASE SELECT ONE OF THE FOLLOWING SORT SEQUENCES"
echo ""
echo "1. SORT ON DOC-DEPT ON DOC-NBR      NUMERIC"
echo ""
echo "2. SORT ON DOC-NAME ON DOC-INITS    ALPHA"
echo ""
echo ""
echo ""
echo "ENTER OPTION:"
$var0 = Read-Host
echo ""
$rcmd = $env:QUIZ + "docpaycode $var0";Invoke-Expression $rcmd > $null;
remove-item docpaycode.txt

if (-not(Test-Path $env:cmd\docpaycode${var0}.ps1 ))
{
        echo "Invalid Option!`a"
        exit
}

&$env:cmd\docpaycode${var0} $var0
copy-item docpaycode1.txt DOCPAYCODE.txt
remove-item docpaycode1.txt
